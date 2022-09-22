using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;

namespace DataAccessLayer.Repositories.Implementations
{
    public class MenuPromoRepository : Repository<MenuPromo>, IMenuPromoRepository
    {
        public MenuPromoRepository(IVRestaurantsContext context) : base(context)
        {
        }
    }
}
