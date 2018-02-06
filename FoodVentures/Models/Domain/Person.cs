using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodVentures.Models.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string FavoriteFoods { get; set; }
        public string FavoriteDestinations { get; set; }
        public string Bio { get; set; }
        public string AvatarUrl { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

    }
}