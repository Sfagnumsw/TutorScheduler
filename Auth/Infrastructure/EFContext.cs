using Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure
{
    public class EFContext(DbContextOptions<EFContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = "teacher" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = "student" });
        }

    }
}
