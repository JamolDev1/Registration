
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapp.Entity;

namespace webapp.Data;

public class RegisterDbContext : IdentityDbContext<User>
{
    public RegisterDbContext(DbContextOptions<RegisterDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity => 
        {
            entity.HasIndex(u => u.UserName).IsUnique();
            entity.HasIndex(u => u.NormalizedUserName).IsUnique();
            entity.HasIndex(u => u.Email).IsUnique();
            entity.HasIndex(u => u.NormalizedEmail).IsUnique();
            entity.HasIndex(u => u.PhoneNumber).IsUnique();
        });
        
    }
}