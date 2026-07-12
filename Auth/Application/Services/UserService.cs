using Auth.Application.Validators;
using Auth.Core.Models;
using Auth.Core.Repository.Providers;
using Auth.DTO;
using Auth.Infrastructure.Kit;
using Auth.Infrastructure.Resources;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace Auth.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryProvider repositoryProvider;
        private readonly IUserValidator userValidator;

        public UserService(IRepositoryProvider repositoryProvider, IUserValidator userValidator)
        {
            this.repositoryProvider = repositoryProvider;
            this.userValidator = userValidator;
        }

        #region [Вход]

        public Task Login()
        {
            throw new NotImplementedException();
        }

        #endregion [Вход]

        #region [Выход]

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        #endregion [Выход]

        #region [Регистрация]

        public async Task Register(UserRegistrationDataDTO dto)
        {
            await userValidator.ValidateUserDto(dto);
            var user = await CreateUserByDto(dto);
            await repositoryProvider.UserRepository.Create(user);
        }

        private async Task<User> CreateUserByDto(UserRegistrationDataDTO dto)
        {
            var passwordHash = PasswordHasher.GetPasswordHash(dto.Password);
            var account = Account.Create(dto.Email, passwordHash);
            var role = await repositoryProvider.RoleRepository.GetRoleByName(dto.RoleName);
            return User.Create(dto.Name, role, dto.TgTag, account);
        }

        #endregion [Регистрация]
    }
}