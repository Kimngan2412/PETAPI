using PETAPI.Model;

namespace PETAPI.Data;

using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        string hashPassword = BCrypt.Net.BCrypt.HashPassword("test");

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Username = "admin",
                Email = "admin@petshop.com",
                PasswordHash = hashPassword,
                Role = "Admin"
            },
            new User
            {
                Id = 2,
                Username = "user1",
                Email = "user1@petshop.com",
                PasswordHash = hashPassword,
                Role = "User"
            }
        );
    }
}