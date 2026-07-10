namespace Auth.Core.Models
{
    public class Role : Entity
    {
        private Role() { }

        public static Role Create(string name) => new() { Name = name };
    }
}
