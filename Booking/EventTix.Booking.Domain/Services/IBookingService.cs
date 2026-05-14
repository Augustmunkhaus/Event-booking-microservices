using BookingEntity = EventTix.Booking.Domain.Entities.Booking;

namespace EventTix.Booking.Domain.Services;

public interface IBookingService
{
    // TODO: Reserve a seat for a user (creates pending booking)
    Task<BookingEntity> ReserveSeatAsync(Guid userId, Guid eventId, Guid seatId);

    // TODO: Confirm a pending booking
    Task<BookingEntity> ConfirmBookingAsync(Guid bookingId, Guid userId);

    // TODO: Cancel a booking
    Task<BookingEntity> CancelBookingAsync(Guid bookingId, Guid userId);

    // TODO: Get booking by id
    Task<BookingEntity> GetBookingByIdAsync(Guid bookingId);

    // TODO: Get all bookings for a user
    Task<List<BookingEntity>> GetBookingsByUserIdAsync(Guid userId);

    // TODO: Expire stale pending bookings (called by background job)
    Task ExpirePendingBookingsAsync();
}
