namespace Auth.Models
{
    public abstract class Entity(string name)
    {
        public int Id { get; set; }
        public string Name { get; set; } = name;
    }
}
