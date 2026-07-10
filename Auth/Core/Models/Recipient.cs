namespace Auth.Core.Models
{
    public class Recipient : Entity
    {
        public Role Role { get; set; } = null!;
        public string TGTag { get; set; } = null!;
    }
}
