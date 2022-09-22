using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;

namespace DataAccessLayer.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IVRestaurantsContext Context;
        public Repository(IVRestaurantsContext context)
        {
            Context = context;
        }
        public void Add(T entity) => Context.Set<T>().Add(entity);

        public void Delete(T entity) => Context.Set<T>().Remove(entity);

        public T? GetById(int id) => Context.Set<T>().Find(id);
    }
}
