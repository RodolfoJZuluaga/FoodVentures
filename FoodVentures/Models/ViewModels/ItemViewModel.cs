using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodVentures.Models.ViewModels
{
    public class ItemViewModel<T1, T2>
    {
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }
    }
}