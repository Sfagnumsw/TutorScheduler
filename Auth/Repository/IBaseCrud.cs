namespace Auth.Repository
{
    public interface IBaseCrud<T> where T : class
    {
        T Get(int id);
        T Create(T entity);
        T Update(T entity);
        T Delete (int id);
    }
}
