using Auth.Infrastructure;
using Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.Repository
{
    public class UserRepository(EFContext efContext) : BaseCrud<User>(efContext), IUserRepository
    {
        public async Task<User?> GetByEmail(string email)
        {
            return await base.context.Users.FirstOrDefaultAsync(x => x.Account.Email == email);
        }
    }
}
