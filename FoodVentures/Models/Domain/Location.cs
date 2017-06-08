using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodVentures.Models.Domain
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}