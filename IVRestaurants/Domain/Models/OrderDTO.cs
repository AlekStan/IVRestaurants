namespace Domain.Models
{
    public class OrderDTO
    {
        public OrderDTO()
        {
            MenuItems = new List<OrderMenuItemDTO>();
            MenuPromos = new List<OrderMenuPromoDTO>();
        }
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderMenuItemDTO> MenuItems { get; set; }
        public List<OrderMenuPromoDTO> MenuPromos { get; set; }
    }
}
