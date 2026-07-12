using Auth.Core.Models;

namespace Auth.Core.Repository
{
    public interface IUserRepository : IBaseCrud<User>
    {
        Task<User?> GetUserByAccount(Account account);
    }
}
