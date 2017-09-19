using System.Collections.Generic;
using FoodVentures.Models.Domain;
using FoodVentures.Models.Requests;

namespace FoodVentures.Services
{
    public interface ITagsService
    {
        List<Tag> Insert(TagsAddRequest model);
        List<Tag> Select(List<string> names);
    }
}