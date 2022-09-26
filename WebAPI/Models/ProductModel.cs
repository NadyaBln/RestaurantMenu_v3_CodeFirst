using Microsoft.AspNetCore.Mvc;
using RestaurantMenu_v3_CodeFirst.Entities;
using System.Collections.Generic;

namespace RestaurantMenu_v3_CodeFirst.Models
{
    public class ProductModel : Controller
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public int Calories { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public bool IsAlcohol { get; set; }
        public bool IsSeason { get; set; }
        public bool IsActive { get; set; }
        public int AllergenId { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
