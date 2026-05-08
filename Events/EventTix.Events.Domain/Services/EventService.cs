using EventTix.Events.Domain.Interfaces;
using EventTix.Events.Domain.Models;

namespace EventTix.Events.Domain.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<List<Event>> GetAllEventsAsync()
    {
        return await _eventRepository.GetAllEventsAsync();
    }

    public async Task<Event> GetEventByIdAsync(Guid eventId)
    {
        var e = await _eventRepository.GetEventByIdAsync(eventId);
        if (e == null) throw new KeyNotFoundException("Event not found.");
        return e;
    }

    public async Task<Event> CreateEventAsync(Event newEvent)
    {
        ValidateEventInput(newEvent);
        return await _eventRepository.CreateEventAsync(newEvent);
    }

    public async Task<Event> UpdateEventAsync(Event e)
    {
        ValidateEventInput(e);

        var existing = await _eventRepository.GetEventByIdAsync(e.Id);
        if (existing == null)
            throw new KeyNotFoundException("Event not found.");
        if (existing.StartsAt < DateTime.UtcNow)
            throw new InvalidOperationException("Cannot update an event that has already started.");
        
        existing.Title = e.Title;
        existing.Description = e.Description;
        existing.StartsAt = e.StartsAt;
        existing.Venue = e.Venue;
        existing.TotalTickets = e.TotalTickets;
        existing.Price = e.Price;
        
        return await _eventRepository.UpdateEventAsync(existing);
    }

    public async Task DeleteEventAsync(Guid id)
    {
        var existing = await _eventRepository.GetEventByIdAsync(id);
        if (existing == null)
            throw new KeyNotFoundException("Event not found.");
        if (existing.StartsAt < DateTime.UtcNow)
            throw new InvalidOperationException("Cannot delete an event that has already started.");

        await _eventRepository.DeleteEventAsync(id);
    }

    private static void ValidateEventInput(Event e)
    {
        if (string.IsNullOrWhiteSpace(e.Title))
            throw new ArgumentException("Title cannot be empty");
        if (e.Price < 0)
            throw new ArgumentException("Price cannot be negative");
        if (e.TotalTickets <= 0)
            throw new ArgumentException("Total tickets must be greater than zero");
        if (e.StartsAt < DateTime.UtcNow)
            throw new ArgumentException("Start time has to be in the future");
    }
}