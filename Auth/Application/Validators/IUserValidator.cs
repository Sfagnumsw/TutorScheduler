using Auth.DTO;

namespace Auth.Application.Validators
{
    public interface IUserValidator
    {
        Task ValidateUserDto(UserRegistrationDataDTO dto);
    }
}
