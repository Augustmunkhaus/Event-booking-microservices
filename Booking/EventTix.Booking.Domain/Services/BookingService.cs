using EventTix.Booking.Domain.Repositories;
using BookingEntity = EventTix.Booking.Domain.Entities.Booking;

namespace EventTix.Booking.Domain.Services;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _repository;

    public BookingService(IBookingRepository repository)
    {
        _repository = repository;
    }

    public Task<BookingEntity> ReserveSeatAsync(Guid userId, Guid eventId, Guid seatId)
    {
        // TODO: Create pending booking with expiration, use optimistic concurrency to prevent double-booking
        throw new NotImplementedException();
    }

    public Task<BookingEntity> ConfirmBookingAsync(Guid bookingId, Guid userId)
    {
        // TODO: Validate ownership, check status is Pending, update to Confirmed
        throw new NotImplementedException();
    }

    public Task<BookingEntity> CancelBookingAsync(Guid bookingId, Guid userId)
    {
        // TODO: Validate ownership, update status to Cancelled
        throw new NotImplementedException();
    }

    public Task<BookingEntity> GetBookingByIdAsync(Guid bookingId)
    {
        // TODO: Retrieve booking, throw KeyNotFoundException if not found
        throw new NotImplementedException();
    }

    public Task<List<BookingEntity>> GetBookingsByUserIdAsync(Guid userId)
    {
        // TODO: Get all bookings for the user
        throw new NotImplementedException();
    }

    public Task ExpirePendingBookingsAsync()
    {
        // TODO: Find pending bookings past ExpiresAt, mark as Expired
        throw new NotImplementedException();
    }
}
