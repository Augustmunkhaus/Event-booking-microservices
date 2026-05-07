using EventTix.Events.Domain.Models;

namespace EventTix.Events.Domain.Interfaces;

public interface IEventRepository
{
    Task<List<Event>> GetAllEventsAsync();
    Task<Event?> GetEventByIdAsync(Guid Id);
    Task<Event> CreateEventAsync(Event e);
    Task<Event> UpdateEventAsync(Event e);
    Task DeleteEventAsync(Guid id);
}