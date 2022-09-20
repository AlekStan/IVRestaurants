namespace Domain.Models
{
    public partial class MenuPromo
    {
        public MenuPromo()
        {
            MenuPromoItems = new HashSet<MenuPromoItem>();
        }

        public int MenuPromoId { get; set; }
        public string MenuPromoName { get; set; } = null!;
        public decimal MenuPromoDiscount { get; set; }
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; } = null!;
        public virtual ICollection<MenuPromoItem> MenuPromoItems { get; set; }
    }
}
