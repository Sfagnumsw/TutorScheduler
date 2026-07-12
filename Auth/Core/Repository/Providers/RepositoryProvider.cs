using Auth.Infrastructure.DataBase;

namespace Auth.Core.Repository.Providers
{
    public class RepositoryProvider : IRepositoryProvider
    {

        public IUserRepository UserRepository { get; }

        public IAccountRepository AccountRepository { get; }

        public IRoleRepository RoleRepository { get; }

        public RepositoryProvider(IUserRepository userRepository, IAccountRepository accountRepository, IRoleRepository roleRepository)
        {
            UserRepository = userRepository;
            AccountRepository = accountRepository;
            RoleRepository = roleRepository;
        }

    }
}
