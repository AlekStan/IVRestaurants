using DataAccessLayer.Repositories.Interfaces;
using Domain.Models;

namespace DataAccessLayer.Repositories.Implementations
{
    public class MenuPromoItemRepository : Repository<MenuPromoItem>, IMenuPromoItemRepository
    {
        public MenuPromoItemRepository(IVRestaurantsContext context) : base(context)
        {
        }
    }
}
