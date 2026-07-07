namespace Auth.Repository
{
    public class BaseCrud<T> : IBaseCrud<T> where T : class
    {
        public T Create(T entity)
        {
            throw new NotImplementedException();
        }

        public T Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
