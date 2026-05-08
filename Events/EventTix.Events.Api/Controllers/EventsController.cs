using EventTix.Events.Domain.Interfaces;
using EventTix.Events.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventTix.Events.Api.Controllers;

[ApiController]
[Route("[controller]")]

public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;
    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }
    
    
    [HttpGet("AllEvents")]
    public async Task<IActionResult> GetAll()
    {
        var events = await _eventService.GetAllEventsAsync();
        return Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var e = await _eventService.GetEventByIdAsync(id);
            return Ok(e);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    [Authorize]
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] EventRequest request)
    {
        try 
        {
            var newEvent = new Event
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                StartsAt = request.StartsAt,
                Venue = request.Venue,
                TotalTickets = request.TotalTickets,
                Price = request.Price
            };
            var created = await _eventService.CreateEventAsync(newEvent);
            return Created($"/events/{created.Id}", created);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] EventRequest request)
    {
        try
        {
            var updated = new Event
            {
                Id = id,
                Title = request.Title,
                Description = request.Description,
                StartsAt = request.StartsAt,
                Venue = request.Venue,
                TotalTickets = request.TotalTickets,
                Price = request.Price
            };
            var result = await _eventService.UpdateEventAsync(updated);
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _eventService.DeleteEventAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    public record EventRequest(
        string Title,
        string Description,
        DateTime StartsAt,
        string Venue,
        int TotalTickets,
        decimal Price);
}