using Microsoft.EntityFrameworkCore;
using BookingEntity = EventTix.Booking.Domain.Entities.Booking;

namespace EventTix.Booking.Infrastructure.Persistence;

public class BookingDbContext : DbContext
{
    public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) { }

    public DbSet<BookingEntity> Bookings => Set<BookingEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookingEntity>(entity =>
        {
            entity.Property(b => b.RowVersion).IsRowVersion();
            entity.HasIndex(b => b.UserId);
            entity.HasIndex(b => b.EventId);
        });
    }
}
