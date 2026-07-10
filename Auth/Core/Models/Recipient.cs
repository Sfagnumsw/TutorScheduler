namespace Auth.Core.Models
{
    public abstract class Recipient : Entity
    {
        protected Recipient() { }

        public Role Role { get; set; } = null!;
        public string TGTag { get; set; } = null!;
    }
}
