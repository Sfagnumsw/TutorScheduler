using Auth.Core.Models;

namespace Auth.Core.Repository
{
    public interface IRoleRepository : IBaseCrud<Role>
    {
        Task<Role?> GetRoleByName(string name);
    }
}
