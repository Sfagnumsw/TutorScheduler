using Auth.Core.Models;
using Auth.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Auth.Core.Repository
{
    public class AccountRepository(EFContext efContext) : BaseCrud<Account>(efContext), IAccountRepository
    {
        public async Task<bool> IsUniqueEmail(string email)
        {
            return !await context.Accounts.AnyAsync(a => a.Email == email);
        }

        /// <summary>
        /// Получить аккаунт по Email
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>Аккаунт</returns>
        public async Task<Account?> GetAccountByEmail(string email)
        {
            return await context.Set<Account>().SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}
