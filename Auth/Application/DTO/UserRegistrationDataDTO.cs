namespace Auth.DTO
{
    public record UserRegistrationDataDTO
    {
        public UserRegistrationDataDTO(string name, string email, string password, string roleName, string tgTag)
        {
            Name = name;
            Email = email;
            Password = password;
            RoleName = roleName;
            TgTag = tgTag;
        }

        public string Name { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string RoleName { get; init; }
        public string TgTag { get; init; }
    }
}