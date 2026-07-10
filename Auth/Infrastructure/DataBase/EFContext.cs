using Auth.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.DataBase
{
    public class EFContext(DbContextOptions<EFContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().HasData(Role.Create("teacher"));
            modelBuilder.Entity<Role>().HasData(Role.Create("student"));

            //TODO Добавить индексы на Account.Email и Role.Name
        }

    }
}
