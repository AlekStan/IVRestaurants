namespace Domain.Models
{
    public class MenuPromoItemDTO
    {
        public int MenuPromoItemId { get; set; }
        public MenuItemDTO MenuItem { get; set; } = null!;
        //public MenuPromoDTO MenuPromo { get; set; } = null!;
    }
}
