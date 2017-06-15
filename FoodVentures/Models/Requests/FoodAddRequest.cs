using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodVentures.Models.Requests
{
    public class FoodAddRequest
    {
        [Required]
        public int PersonId { get; set; }
        [Required]
        public string Name { get; set; }
        public LocationAddRequest Location { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public string Url { get; set; }
    }
}