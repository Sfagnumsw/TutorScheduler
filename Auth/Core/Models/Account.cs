namespace Auth.Core.Models
{
    public class Account
    {
        protected Account() { }

        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public static Account Create(string email, string password) => new() { Email = email, Password = password };
    }
}
