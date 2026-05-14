using EventTix.Booking.Domain.Entities;

namespace EventTix.Booking.Api.Dtos;

public record BookingResponse(
    Guid Id,
    Guid UserId,
    Guid EventId,
    Guid SeatId,
    BookingStatus Status,
    DateTime ExpiresAt,
    DateTime CreatedAt);
