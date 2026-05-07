using EventTix.Events.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EventTix.Events.Infrastructure;

public class EventsDbContext : DbContext
{
    public EventsDbContext(DbContextOptions<EventsDbContext> options) : base(options) { }
    
    public DbSet<Event> Event => Set<Event>();
    
    //extra rules
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>().Property(e => e.Price).HasPrecision(18, 2);
    }
    
}
