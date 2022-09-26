
using System;

namespace RestaurantMenu_v3_CodeFirst.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int OrderItemId { get; set; }
        public virtual OrderItem OrderItem { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int GuestId { get; set; }
        public virtual Guest Guest { get; set; }
        public int TableNumber { get; set; }
    }
}
