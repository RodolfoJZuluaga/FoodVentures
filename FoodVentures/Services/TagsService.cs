using FoodVentures.Models.Domain;
using FoodVentures.Models.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WikiDataProvider.Data;
using WikiDataProvider.Data.Extensions;
using WikiDataProvider.Data.Interfaces;

namespace FoodVentures.Services
{
    public class TagsService
    {
        public List<Tag> Select(List<string> names)
        {
            List<Tag> list = null;
            DataTable tvp = new DataTable();
            DataProvider.ExecuteCmd(
                GetConnection,
                "Tags_Select",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@names", ArrayToTable(names));
                },
                map: delegate (IDataReader reader, short set)
                {
                    Tag t = new Tag();
                    int startingIndex = 0;
                    t.Id = reader.GetSafeInt32(startingIndex++);
                    t.TagName = reader.GetSafeString(startingIndex++);
                    if (list == null)
                    {
                        list = new List<Tag>();
                    }
                    list.Add(t);
                });
            return list;
        }
        public List<Tag> Insert(TagsAddRequest model)
        {
            List<Tag> list = null;
            DataTable tvp = new DataTable();
            DataProvider.ExecuteCmd(
                GetConnection,
                "Tags_Insert",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@names", ArrayToTable(model.TagNames));
                },
                map: delegate (IDataReader reader, short set)
                {
                    Tag t = new Tag();
                    int startingIndex = 0;
                    t.Id = reader.GetSafeInt32(startingIndex++);
                    t.TagName = reader.GetSafeString(startingIndex++);
                    if (list == null)
                    {
                        list = new List<Tag>();
                    }
                    list.Add(t);
                });
            return list;
        }

        private static DataTable ArrayToTable(List<string> names)
        {
            DataTable table = new DataTable();
            table.Columns.Add("TagNames", typeof(string));
            foreach (var item in names)
            {
                table.Rows.Add(item);
            }
            return table;
        }

        protected static IDao DataProvider
        {
            get { return WikiDataProvider.Data.DataProvider.Instance; }
        }
        protected static SqlConnection GetConnection()
        {
            return new System.Data.SqlClient.SqlConnection(
                System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
    }
}