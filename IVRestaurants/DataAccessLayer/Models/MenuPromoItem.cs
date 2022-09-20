namespace Domain.Models
{
    public partial class MenuPromoItem
    {
        public int MenuPromoItemId { get; set; }
        public int MenuItemId { get; set; }
        public int MenuPromoId { get; set; }

        public virtual MenuItem MenuItem { get; set; } = null!;
        public virtual MenuPromo MenuPromo { get; set; } = null!;
    }
}
