using EventTix.Identity.Domain;
using EventTix.Identity.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventTix.Identity.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService) => _userService = userService;
    
   //equivalent to a DTO
   public record Request(string Email, string Password);

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody]Request request)
    {
        try
        {
            var user = await _userService.RegisterAsync(request.Email, request.Password);
            return Created($"/users/{user.Id}", new { user.Id, user.Email });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] Request request)
    {
        
        var user = await _userService.LoginAsync(request.Email, request.Password);
        
        if (user == null)
        { 
            return Unauthorized("Invalid username or password");
        }
            
        return Ok(new { user.Id, user.Email });
    }
}

