namespace Auth.Models
{
    public class Account(string email, string password)
    {
        public int Id { get; set; }
        public string Email { get; set; } = email;
        public string Password { get; set; } = password;
    }
}
