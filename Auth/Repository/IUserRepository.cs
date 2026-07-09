using Auth.Models;

namespace Auth.Repository
{
    public interface IUserRepository : IBaseCrud<User>
    {
        Task<User?> GetByEmail(string email);
    }
}
