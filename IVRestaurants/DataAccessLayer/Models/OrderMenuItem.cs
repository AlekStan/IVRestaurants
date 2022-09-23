namespace DataAccessLayer.Models
{
    public partial class OrderMenuItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public decimal MenuItemPrice { get; set; }
        public int MenuItemId { get; set; }

        public virtual MenuItem MenuItem { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
