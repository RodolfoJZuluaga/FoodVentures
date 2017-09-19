using System.Collections.Generic;
using FoodVentures.Models.Requests;

namespace FoodVentures.Services
{
    public interface IFoodTagsService
    {
        void Insert(List<FoodTagsAddRequest> list);
    }
}