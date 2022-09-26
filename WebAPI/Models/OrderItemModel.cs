using Microsoft.AspNetCore.Mvc;
using RestaurantMenu_v3_CodeFirst.Entities;
using System.Collections.Generic;

namespace RestaurantMenu_v3_CodeFirst.Models
{
    public class OrderItemModel : Controller
    {
        public int OrderItemId { get; set; }
        public virtual Order Order { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
