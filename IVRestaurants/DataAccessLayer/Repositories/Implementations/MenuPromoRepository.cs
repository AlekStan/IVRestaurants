using DataAccessLayer.Repositories.Interfaces;
using Domain.Models;

namespace DataAccessLayer.Repositories.Implementations
{
    public class MenuPromoRepository : Repository<MenuPromo>, IMenuPromoRepository
    {
        public MenuPromoRepository(IVRestaurantsContext context) : base(context)
        {
        }
    }
}
