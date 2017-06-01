using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodVentures.Models.Requests
{
    public class TagsAddRequest
    {
        [Required]
        public List<string> TagNames { get; set; }
    }
}