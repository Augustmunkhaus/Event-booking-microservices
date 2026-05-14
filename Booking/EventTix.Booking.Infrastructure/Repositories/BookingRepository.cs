using EventTix.Booking.Domain.Entities;
using EventTix.Booking.Domain.Repositories;
using EventTix.Booking.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using BookingEntity = EventTix.Booking.Domain.Entities.Booking;

namespace EventTix.Booking.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly BookingDbContext _db;

    public BookingRepository(BookingDbContext db) => _db = db;

    public async Task<BookingEntity?> GetBookingByIdAsync(Guid id)
    {
        return await _db.Bookings.FindAsync(id);
    }

    public async Task<List<BookingEntity>> GetBookingsByUserIdAsync(Guid userId)
    {
        // TODO: Filter bookings by UserId, return as list
        return await _db.Bookings.Where(x => x.UserId == userId).ToListAsync();
    }

    public async Task<BookingEntity> AddBookingAsync(BookingEntity booking)
    {
        // TODO: Add booking, save changes, return booking
        _db.Bookings.Add(booking);
        await _db.SaveChangesAsync();
        return booking;
    }

    public async Task<BookingEntity> UpdateBookingAsync(BookingEntity booking)
    {
        // TODO: Update booking, save changes (EF will check RowVersion)
        _db.Bookings.Update(booking);
        await _db.SaveChangesAsync();
        return booking;
    }

    public async Task<List<BookingEntity>> GetExpiredPendingBookingsAsync()
    {
        return await _db.Bookings
            .Where(x => x.Status == BookingStatus.Pending &&
                   x.ExpiresAt < DateTime.UtcNow).ToListAsync();
    }
    
    public async Task<int> GetActiveTicketCountForEventAsync(Guid eventId)
    {
        return await _db.Bookings
            .Where(x => x.EventId == eventId 
                        && (x.Status == BookingStatus.Pending 
                            || x.Status == BookingStatus.Confirmed))
            .SumAsync(x => x.Quantity);

    }
}
