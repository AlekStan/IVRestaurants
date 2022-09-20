using DataAccessLayer.Repositories.Interfaces;
using Domain.Models;

namespace DataAccessLayer.Repositories.Implementations
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(IVRestaurantsContext context) : base(context)
        {
        }
    }
}
