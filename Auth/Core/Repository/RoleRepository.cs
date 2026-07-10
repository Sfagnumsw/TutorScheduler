using Auth.Core.Models;
using Auth.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Auth.Core.Repository
{
    public class RoleRepository(EFContext efContext) : BaseCrud<Role>(efContext), IRoleRepository
    {
        /// <summary>
        /// Найти роль по наименованию
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <returns>Роль</returns>
        public async Task<Role?> GetRoleByName(string name)
        {
            return await context.Roles.SingleOrDefaultAsync(x => x.Name == name);
        }
    }
}
