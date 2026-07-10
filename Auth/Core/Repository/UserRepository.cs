using Auth.Core.Models;
using Auth.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Auth.Core.Repository
{
    public class UserRepository(EFContext efContext) : BaseCrud<User>(efContext), IUserRepository
    {
        public async Task<User?> GetByEmail(string email)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Account.Email == email);
        }
    }
}
