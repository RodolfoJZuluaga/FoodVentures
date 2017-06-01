using FoodVentures.Models.Domain;
using FoodVentures.Models.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WikiDataProvider.Data.Extensions;
using WikiDataProvider.Data.Interfaces;

namespace FoodVentures.Services
{
    public class FoodTagsService
    {
        public void Insert(List<FoodTagsAddRequest> list)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.FoodTags_Insert"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@FoodTags", ArrayToTable(list));

                }, returnParameters: null
                );
        }

        //private static DataTable ArrayToTable(List<FoodTagsAddRequest> model)
        //{
        //    DataTable table = new DataTable();
        //    table.Columns.Add("FoodId", typeof(int));
        //    table.Columns.Add("TagId", typeof(int));

        //    foreach (var ft in model.FoodId.Zip(model.TagId, Tuple.Create))
        //    {
        //        table.Rows.Add(ft.Item1 + ft.Item2);
        //    }
        //    return table;
        //}
        private static DataTable ArrayToTable(List<FoodTagsAddRequest> list)
        {
            DataTable table = new DataTable();
            table.Columns.Add("FoodId", typeof(int));
            table.Columns.Add("TagId", typeof(int));
            foreach (var item in list)
            {
                table.Rows.Add(item.FoodId, item.TagId);
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