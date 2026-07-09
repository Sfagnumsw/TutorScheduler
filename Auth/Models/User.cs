namespace Auth.Models
{
    public class User : Recipient
    {
        public Account Account{ get; set; } = null!;
    }
}
