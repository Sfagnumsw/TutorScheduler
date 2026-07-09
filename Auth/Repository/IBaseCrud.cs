namespace Auth.Repository
{
    public interface IBaseCrud<T> where T : class
    {
        Task<T?> Get(int id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete (int id);
        Task<IEnumerable<T>> GetAll();
    }
}
