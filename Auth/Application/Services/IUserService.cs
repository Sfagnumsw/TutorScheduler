using Auth.DTO;

namespace Auth.Application.Services
{
    public interface IUserService
    {
        Task Register(UserRegistrationDataDTO dto);
        Task Login();
        Task Logout();
    }
}
