using System.Collections.Generic;

namespace RestaurantMenu_v3_CodeFirst.Entities
{
    public class OrderItem
    {
        //public OrderItem()
        //{
        //    this.Products = new HashSet<Product>(); 
        //}
        public int OrderItemId { get; set; }
        public virtual Order Order { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
