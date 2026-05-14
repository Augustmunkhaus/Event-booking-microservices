using EventTix.Booking.Api.Dtos;
using EventTix.Booking.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventTix.Booking.Api.Controllers;

[ApiController]
[Route("api/bookings")]
[Authorize]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingsController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpPost("reserve")]
    public IActionResult Reserve([FromBody] ReserveSeatRequest request)
    {
        // TODO: Get userId from JWT claims, call ReserveSeatAsync, return Created with BookingResponse
        return StatusCode(501);
    }

    [HttpPost("{id}/confirm")]
    public IActionResult Confirm(Guid id)
    {
        // TODO: Get userId from JWT claims, call ConfirmBookingAsync, return Ok with BookingResponse
        return StatusCode(501);
    }

    [HttpPost("{id}/cancel")]
    public IActionResult Cancel(Guid id)
    {
        // TODO: Get userId from JWT claims, call CancelBookingAsync, return Ok with BookingResponse
        return StatusCode(501);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        // TODO: Get booking by id, verify ownership, return BookingResponse
        return StatusCode(501);
    }

    [HttpGet("me")]
    public IActionResult GetMyBookings()
    {
        // TODO: Get userId from JWT claims, return list of BookingResponse
        return StatusCode(501);
    }
}
