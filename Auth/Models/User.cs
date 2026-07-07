namespace Auth.Models
{
    public class User(string name, Role role, string tgTag, Account account) : Recipient(name, role, tgTag)
    {
        public Account Account { get; set; } = account;
    }
}
