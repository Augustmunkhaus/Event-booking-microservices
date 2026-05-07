using EventTix.Events.Domain.Interfaces;
using EventTix.Events.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EventTix.Events.Infrastructure.Repositories;

public class EventRepository : IEventRepository
{
    private readonly EventsDbContext _db;
    public EventRepository(EventsDbContext db) => _db = db;

    public async Task<List<Event>> GetAllEventsAsync()
    {
        return await _db.Event.ToListAsync();
    }

    public async Task<Event?> GetEventByIdAsync(Guid id) =>
        await _db.Event.FindAsync(id);

    public async Task<Event> CreateEventAsync(Event e)
    {
        _db.Event.Add(e);
        await _db.SaveChangesAsync();
        return e;
    }

    public async Task<Event> UpdateEventAsync(Event e)
    {
        _db.Event.Update(e);
        await _db.SaveChangesAsync();
        return e;
    }
    
    public async Task DeleteEventAsync(Guid id)
    {
        var Event = await _db.Event.FindAsync(id);
        if (Event == null) return;
        _db.Event.Remove(Event);
        await _db.SaveChangesAsync();
    }
}