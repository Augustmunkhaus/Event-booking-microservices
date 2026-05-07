namespace EventTix.Events.Domain.Models;

public class Event
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartsAt { get; set; }
    public string Venue { get; set; } = string.Empty;
    public int TotalTickets { get; set; }
    public decimal Price { get; set; }
}