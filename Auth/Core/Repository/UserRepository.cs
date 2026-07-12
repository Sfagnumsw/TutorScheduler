using Auth.Core.Models;
using Auth.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Auth.Core.Repository
{
    public class UserRepository(EFContext efContext) : BaseCrud<User>(efContext), IUserRepository
    {
        public async Task<User?> GetUserByAccount(Account account)
        {
            return await context.Users.AsNoTracking().SingleOrDefaultAsync(x => Equals(x.Account == account));
        }
    }
}
