namespace EventTix.Booking.Api.Dtos;

public record ReserveSeatRequest(Guid EventId, Guid SeatId);
