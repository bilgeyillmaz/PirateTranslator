using CaseAFS.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseAFS.DataAccess
{
    public class CaseAfsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = DESKTOP-HNE43R2; database = CaseAfsDb; integrated security = true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
               new User { UserId = 1, Email = "admin@admin.com", FirstName = "Admin", LastName = "Admin", PhoneNumber = "5554443322", Password = "Test123!", PasswordRepeat = "Test123!", RoleId = 1 },
               new User { UserId = 2, Email = "member@member.com", FirstName = "Member", LastName = "Member", PhoneNumber = "5554443322", Password = "Test123!", PasswordRepeat = "Test123!", RoleId = 2 });
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "Member" });
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}

