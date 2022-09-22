namespace DataAccessLayer.Models
{
    public partial class OrderMenuPromo
    {
        public int OrderPromoId { get; set; }
        public int OrderId { get; set; }
        public decimal MenuPromoPrice { get; set; }
        public int MenuPromoId { get; set; }

        public virtual MenuPromo MenuPromo { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
