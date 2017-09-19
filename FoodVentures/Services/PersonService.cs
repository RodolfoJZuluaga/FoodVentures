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
    public class PersonService : IPersonService
    {
        public Person Select(int id)
        {
            Person p = new Person();
            DataProvider.ExecuteCmd(
                GetConnection,
                "People_SelectById",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@id", id);
                },
                map: delegate (IDataReader reader, short set)
                {
                    int startingIndex = 0;
                    p.Id = reader.GetSafeInt32(startingIndex++);
                    p.DateCreated = reader.GetSafeDateTime(startingIndex++);
                    p.DateModified = reader.GetSafeDateTime(startingIndex++);
                    p.FirstName = reader.GetSafeString(startingIndex++);
                    p.LastName = reader.GetSafeString(startingIndex++);
                    p.Location = reader.GetSafeString(startingIndex++);
                    p.FavoriteFoods = reader.GetSafeString(startingIndex++);
                    p.FavoriteDestinations = reader.GetSafeString(startingIndex++);
                    p.Bio = reader.GetSafeString(startingIndex++);
                    p.AvatarUrl = reader.GetSafeString(startingIndex++);
                    p.Email = reader.GetSafeString(startingIndex++);
                });
            return p;
        }
        public int Insert(PersonAddRequest model)
        {
            int Id = 0;
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.People_Insert"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@UserId", model.UserId);
                    paramCollection.AddWithValue("@FirstName", model.FirstName);
                    paramCollection.AddWithValue("@LastName", model.LastName);
                    paramCollection.AddWithValue("@Location", model.Location);
                    paramCollection.AddWithValue("@FavoriteFoods", model.FavoriteFoods);
                    paramCollection.AddWithValue("@FavoriteDestinations", model.FavoriteDestinations);
                    paramCollection.AddWithValue("@Bio", model.Bio);
                    paramCollection.AddWithValue("@AvatarUrl", model.AvatarUrl);

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
        public Person SelectByUserId(string userId)
        {
            Person p = new Person();
            DataProvider.ExecuteCmd(
                GetConnection,
                "People_SelectByUserId",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@UserId", userId);
                },
                map: delegate (IDataReader reader, short set)
                {
                    int startingIndex = 0;
                    p.Id = reader.GetSafeInt32(startingIndex++);
                    p.DateCreated = reader.GetSafeDateTime(startingIndex++);
                    p.DateModified = reader.GetSafeDateTime(startingIndex++);
                    p.FirstName = reader.GetSafeString(startingIndex++);
                    p.LastName = reader.GetSafeString(startingIndex++);
                    p.Location = reader.GetSafeString(startingIndex++);
                    p.FavoriteFoods = reader.GetSafeString(startingIndex++);
                    p.FavoriteDestinations = reader.GetSafeString(startingIndex++);
                    p.Bio = reader.GetSafeString(startingIndex++);
                    p.AvatarUrl = reader.GetSafeString(startingIndex++);
                    p.Email = reader.GetSafeString(startingIndex++);
                });
            return p;
        }

        public void UpdatePerson(PersonUpdateRequest model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.People_Update",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", model.Id);
                    paramCollection.AddWithValue("@FirstName", model.FirstName);
                    paramCollection.AddWithValue("@LastName", model.LastName);
                    paramCollection.AddWithValue("@Location", model.Location);
                    paramCollection.AddWithValue("@FavoriteFoods", model.FavoriteFoods);
                    paramCollection.AddWithValue("@FavoriteDestinations", model.FavoriteDestinations);
                    paramCollection.AddWithValue("@Bio", model.Bio);
                    paramCollection.AddWithValue("@AvatarUrl", model.AvatarUrl);
                }, returnParameters: null
                );
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