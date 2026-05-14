using BookingEntity = EventTix.Booking.Domain.Entities.Booking;

namespace EventTix.Booking.Domain.Repositories;

public interface IBookingRepository
{
    // TODO: Get booking by id
    Task<BookingEntity?> GetBookingByIdAsync(Guid id);

    // TODO: Get all bookings for a user
    Task<List<BookingEntity>> GetBookingsByUserIdAsync(Guid userId);

    // TODO: Add a new booking
    Task<BookingEntity> AddBookingAsync(BookingEntity booking);

    // TODO: Update an existing booking (handles optimistic concurrency)
    Task<BookingEntity> UpdateBookingAsync(BookingEntity booking);

    // TODO: Get pending bookings that have expired
    Task<List<BookingEntity>> GetExpiredPendingBookingsAsync();
    
    Task<int> GetActiveTicketCountForEventAsync(Guid eventId);
    
}
