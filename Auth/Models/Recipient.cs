namespace Auth.Models
{
    public class Recipient(string name, Role role, string tgTag) : Entity(name)
    {
        public Role Role { get; set; } = role;
        public string TGTag { get; set; } = tgTag;
    }
}
