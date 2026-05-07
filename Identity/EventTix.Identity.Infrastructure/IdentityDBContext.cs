using EventTix.Identity.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventTix.Identity.Infrastructure;
//translates LINQ to SQL and manages the connection to Postgres.
public class IdentityDbContext : DbContext
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();

    //extra rules
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
    }
}