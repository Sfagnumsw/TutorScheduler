using Auth.Core.Models;

namespace Auth.Core.Repository
{
    public interface IAccountRepository : IBaseCrud<Account>
    {
        Task<bool> IsUniqueEmail(string email);
        Task<Account?> GetAccountByEmail(string email);
    }
}
