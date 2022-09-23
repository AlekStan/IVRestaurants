namespace DataAccessLayer.Models
{
    public partial class MenuItem
    {
        public MenuItem()
        {
            MenuPromoItems = new HashSet<MenuPromoItem>();
            OrderMenuItems = new HashSet<OrderMenuItem>();
        }

        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; } = null!;
        public decimal MenuItemPrice { get; set; }
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; } = null!;
        public virtual ICollection<MenuPromoItem> MenuPromoItems { get; set; }
        public virtual ICollection<OrderMenuItem> OrderMenuItems { get; set; }
    }
}
