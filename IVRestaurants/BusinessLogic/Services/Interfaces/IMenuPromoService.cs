using Domain.Models;

namespace BusinessLogic.Services.Interfaces
{
    public interface IMenuPromoService
    {
        public decimal CalculateMenuPromoPrice(MenuPromoDTO menuPromo);
    }
}
