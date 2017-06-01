using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodVentures.Models.Requests
{
    public class PersonUpdateRequest : PersonAddRequest
    {
        [Required]
        public int Id { get; set; }
    }
}