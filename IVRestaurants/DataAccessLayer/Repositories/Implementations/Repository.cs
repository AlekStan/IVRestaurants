using DataAccessLayer.Repositories.Interfaces;
using Domain.Models;

namespace DataAccessLayer.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected IVRestaurantsContext Context;
        public Repository(IVRestaurantsContext context)
        {
            Context = context;
        }
        public void Add(T entity) => Context.Set<T>().Add(entity);

        public void Delete(T entity) => Context.Set<T>().Remove(entity);
    }
}
