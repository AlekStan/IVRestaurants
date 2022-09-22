namespace Domain.Models
{
    public class OrderDTO
    {
        public OrderDTO()
        {
            MenuItems = new List<MenuItemDTO>();
            MenuPromos = new List<MenuPromoDTO>();
        }
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public List<MenuItemDTO> MenuItems { get; set; }
        public List<MenuPromoDTO> MenuPromos { get; set; }
    }
}
