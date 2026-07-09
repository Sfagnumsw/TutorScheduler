using Auth.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Auth.Repository
{
    public abstract class BaseCrud<T>(EFContext efContext) : IBaseCrud<T> where T : class
    {
        protected readonly EFContext context = efContext;

        public async Task<T?> Get(int id) => await context.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> GetAll() => await context.Set<T>().ToListAsync();

        public async Task Create(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await Get(id);
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
