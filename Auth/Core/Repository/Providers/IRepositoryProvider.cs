namespace Auth.Core.Repository.Providers
{
    public interface IRepositoryProvider
    {
        IUserRepository UserRepository { get; }
        IAccountRepository AccountRepository { get; }
        IRoleRepository RoleRepository { get; }
    }
}
