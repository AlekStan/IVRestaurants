namespace DataAccessLayer.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            MenuItems = new HashSet<MenuItem>();
            MenuPromos = new HashSet<MenuPromo>();
        }

        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; } = null!;

        public virtual ICollection<MenuItem> MenuItems { get; set; }
        public virtual ICollection<MenuPromo> MenuPromos { get; set; }
    }
}
