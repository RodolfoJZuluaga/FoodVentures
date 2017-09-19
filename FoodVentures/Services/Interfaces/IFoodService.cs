using System.Collections.Generic;
using FoodVentures.Models.Domain;
using FoodVentures.Models.Requests;

namespace FoodVentures.Services
{
    public interface IFoodService
    {
        void Delete(int id);
        List<Food> GetFoodById(int personId);
        int Insert(FoodAddRequest model);
    }
}