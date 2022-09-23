namespace Domain.Models
{
    public class MenuPromoDTO
    {
        public MenuPromoDTO()
        {
            MenuPromoItems = new List<MenuPromoItemDTO>();
        }
        public int MenuPromoId { get; set; }
        public string MenuPromoName { get; set; } = null!;
        public decimal MenuPromoDiscount { get; set; }
        public decimal MenuPromoPrice { get; set; }
        public int RestaurantId { get; set; }

        public List<MenuPromoItemDTO> MenuPromoItems { get; set; }
    }
}
