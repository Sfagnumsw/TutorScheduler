using Auth.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Auth.Core.Repository
{
    public abstract class BaseCrud<T>(EFContext efContext) : IBaseCrud<T> where T : class
    {
        protected readonly EFContext context = efContext;

        /// <summary>
        /// Получить сущность по ИД
        /// </summary>
        /// <param name="id">ИД</param>
        /// <returns>Сущность</returns>
        public async Task<T?> Get(int id) => await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);

        /// <summary>
        /// Получить все сущности данного типа
        /// </summary>
        /// <returns>Список сущностей</returns>
        public async Task<IEnumerable<T>> GetAll() => await context.Set<T>().AsNoTracking().ToListAsync();

        /// <summary>
        /// Сохранить сущность в БД
        /// </summary>
        /// <param name="entity">Сущность</param>
        public async Task Create(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить сущность из БД по ИД
        /// </summary>
        /// <param name="id">ИД</param>
        public async Task Delete(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Обновить поля сущности
        /// </summary>
        /// <param name="entity">Обновленная сущность</param>
        public async Task Update(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
