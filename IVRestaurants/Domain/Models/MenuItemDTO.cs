namespace Domain.Models
{
    public class MenuItemDTO
    {
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; } = null!;
        public decimal MenuItemPrice { get; set; }
        public int RestaurantId { get; set; }
    }
}
