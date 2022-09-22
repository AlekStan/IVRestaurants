namespace DataAccessLayer.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderMenuItems = new HashSet<OrderMenuItem>();
            OrderMenuPromos = new HashSet<OrderMenuPromo>();
        }

        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<OrderMenuItem> OrderMenuItems { get; set; }
        public virtual ICollection<OrderMenuPromo> OrderMenuPromos { get; set; }
    }
}
