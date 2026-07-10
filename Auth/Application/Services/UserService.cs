using Auth.Core.Models;
using Auth.Core.Repository;
using Auth.DTO;
using Auth.Infrastructure.Kit;

namespace Auth.Application.Services
{
    public class UserService : IUserService
    {
        protected readonly IUserRepository userRepository;
        protected readonly IBaseCrud<Account> accountRepository;
        protected readonly IRoleRepository roleRepository;

        public UserService(IUserRepository userRepository, IBaseCrud<Account> accountRepository, IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.accountRepository = accountRepository;
            this.roleRepository = roleRepository;
        }


        public Task Login()
        {
            throw new NotImplementedException();
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public async Task Register(UserRegistrationDataDTO dto)
        {
            var user = CreateUserByDto(dto);

        }

        private async Task<User> CreateUserByDto(UserRegistrationDataDTO dto)
        {
            var passwordHash = PasswordHasher.GetPasswordHash(dto.Password);
            var account = Account.Create(dto.Email, passwordHash);
            var role = await roleRepository.GetRoleByName(dto.RoleName);
            return User.Create(dto.Name, role, dto.TgTag, account);
        }

        private async Task<bool> 
    }
}
