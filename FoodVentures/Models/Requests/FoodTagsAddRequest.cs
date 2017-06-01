using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodVentures.Models.Requests
{
    public class FoodTagsAddRequest
    {
        [Required]
        public int FoodId { get; set; }
        [Required]
        public int TagId { get; set; }
    }
}