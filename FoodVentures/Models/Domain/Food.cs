using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodVentures.Models.Domain
{
    public class Food
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public string Url { get; set; }
        public List<Tag> Tags { get; set; }
        public Location Location { get; set; }

    }
}