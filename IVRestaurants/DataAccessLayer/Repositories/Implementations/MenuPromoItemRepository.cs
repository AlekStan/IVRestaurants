using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;

namespace DataAccessLayer.Repositories.Implementations
{
    public class MenuPromoItemRepository : Repository<MenuPromoItem>, IMenuPromoItemRepository
    {
        public MenuPromoItemRepository(IVRestaurantsContext context) : base(context)
        {
        }
    }
}
