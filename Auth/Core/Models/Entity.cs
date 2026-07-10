namespace Auth.Core.Models
{
    public abstract class Entity
    {
        protected Entity() { }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
