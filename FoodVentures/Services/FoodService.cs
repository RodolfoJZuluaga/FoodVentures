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
    public class FoodService
    {
        public int Insert(FoodAddRequest model)
        {
            int Id = 0;
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Food_Insert"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@PersonId", model.PersonId);
                    paramCollection.AddWithValue("@Name", model.Name);
                    paramCollection.AddWithValue("@Location", model.Location);
                    paramCollection.AddWithValue("@Comment", model.Comment);
                    paramCollection.AddWithValue("@Url", model.Url);

                    SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                    p.Direction = System.Data.ParameterDirection.Output;

                    paramCollection.Add(p);

                }, returnParameters: delegate (SqlParameterCollection param)
                {
                    int.TryParse(param["@Id"].Value.ToString(), out Id);
                }
                );
            return Id;
        }
        public List<Food> GetFoodById(int personId)
        {
            List<Food> list = null;
            Dictionary<int, Food> dictionary = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Food_SelectByPersonId",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@PersonId", personId);
                }, map: delegate (IDataReader reader, short set)
                {
                    switch (set)
                    {
                        case 0:
                            int startingIndex = 0;
                            Food f = new Food();

                            f.Id = reader.GetSafeInt32(startingIndex++);
                            f.PersonId = reader.GetSafeInt32(startingIndex++);
                            f.Name = reader.GetSafeString(startingIndex++);
                            f.Location = reader.GetSafeString(startingIndex++);
                            f.Comment = reader.GetSafeString(startingIndex++);
                            f.DateCreated = reader.GetSafeDateTime(startingIndex++);
                            f.Url = reader.GetSafeString(startingIndex++);

                            if (list == null)
                            {
                                list = new List<Food>();
                            }
                            list.Add(f);
                            if (dictionary == null)
                            {
                                dictionary = new Dictionary<int, Food>();
                            }
                            dictionary.Add(f.Id, f);
                            break;
                        case 1:
                            int foodId = 0;
                            Tag tag = MapTag(reader, out foodId);
                            Food parent = dictionary[foodId];
                            if (parent.Tags == null)
                            {
                                parent.Tags = new List<Tag>();
                            }
                            parent.Tags.Add(tag);
                            break;
                    }


                });

            return list;
        }
        public void Delete(int id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Food_DeleteById"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);

                }, returnParameters: null
                );
        }
        private static Tag MapTag(IDataReader reader, out int parentFoodId)
        {
            Tag t = new Tag();
            int startingIndex = 0;
            parentFoodId = reader.GetSafeInt32(startingIndex++);
            t.Id = reader.GetSafeInt32(startingIndex++);
            t.TagName = reader.GetSafeString(startingIndex++);
            return t;
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