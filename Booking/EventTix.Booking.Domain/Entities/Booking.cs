namespace EventTix.Booking.Domain.Entities;

// TODO: Complete entity implementation
public class Booking
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid EventId { get; set; }
    public int Quantity { get; set; }
    public BookingStatus Status { get; set; }
    public DateTime ExpiresAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public byte[] RowVersion { get; set; } = Array.Empty<byte>();
}
