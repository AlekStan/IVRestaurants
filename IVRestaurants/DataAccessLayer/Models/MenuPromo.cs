namespace DataAccessLayer.Models
{
    public partial class MenuPromo
    {
        public MenuPromo()
        {
            MenuPromoItems = new HashSet<MenuPromoItem>();
            OrderMenuPromos = new HashSet<OrderMenuPromo>();
        }

        public int MenuPromoId { get; set; }
        public string MenuPromoName { get; set; } = null!;
        public decimal MenuPromoDiscount { get; set; }
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; } = null!;
        public virtual ICollection<MenuPromoItem> MenuPromoItems { get; set; }
        public virtual ICollection<OrderMenuPromo> OrderMenuPromos { get; set; }
    }
}
