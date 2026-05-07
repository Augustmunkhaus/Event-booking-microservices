using EventTix.Events.Domain.Models;

namespace EventTix.Events.Domain.Interfaces;

public interface IEventService
{
    Task<List<Event>> GetAllEventsAsync();
    Task<Event> GetEventByIdAsync(Guid eventId);
    Task<Event> CreateEventAsync(Event newEvent);
    Task<Event> UpdateEventAsync(Event e);
    Task DeleteEventAsync(Guid eventId);
}