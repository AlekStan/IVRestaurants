namespace Domain.Models
{
    public class ShoppingCartDTO
    {
        public ShoppingCartDTO()
        {
            MenuItems = new List<MenuItemDTO>();
            MenuPromos = new List<MenuPromoDTO>()
        }
        public decimal TotalAmount { get; set; }
        public List<MenuItemDTO> MenuItems { get; set; }
        public List<MenuPromoDTO> MenuPromos { get; set; }
    }
}
