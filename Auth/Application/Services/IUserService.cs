namespace Auth.Application.Services
{
    public interface IUserService
    {
        Task Register(string name, string email, string password, string roleName, string tgTag);
    }
}
