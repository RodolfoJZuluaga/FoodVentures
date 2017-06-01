using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodVentures.Models.Requests
{
    public class PersonAddRequest
    {
        [Required]
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string FavoriteFoods { get; set; }
        public string FavoriteDestinations { get; set; }
        public string Bio { get; set; }
        public string AvatarUrl { get; set; }
    }
}