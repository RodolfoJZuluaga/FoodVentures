using FoodVentures.Models.Domain;
using FoodVentures.Models.Requests;

namespace FoodVentures.Services
{
    public interface IPersonService
    {
        int Insert(PersonAddRequest model);
        Person Select(int id);
        Person SelectByUserId(string userId);
        void UpdatePerson(PersonUpdateRequest model);
        Person SelectByUserUrl(string userUrl);
    }
}