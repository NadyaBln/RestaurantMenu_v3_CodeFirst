
namespace RestaurantMenu_v3_CodeFirst.Entities
{
    public class Guest
    {
        public int GuestId { get; set; }
        public string GuestName { get; set; }
        public string GuestEmail { get; set; }
        public bool IsAdmin { get; set; }
        public virtual Order Order { get; set; }
    }
}
