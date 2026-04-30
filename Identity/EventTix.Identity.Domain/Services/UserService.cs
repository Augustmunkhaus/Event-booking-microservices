using EventTix.Identity.Infrastructure;
using Microsoft.AspNetCore.Identity;
namespace EventTix.Identity.Domain;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;
    private readonly PasswordHasher<User> _hasher = new();

    public UserService(IUserRepository repo) => _repo = repo; 
    
    public async Task<User> RegisterAsync(string email, string password)
    {
        if (await _repo.EmailExistsAsync(email))
            throw new InvalidOperationException("Email already in use.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            CreatedAt = DateTime.UtcNow
        };
        user.PasswordHash = _hasher.HashPassword(user, password);

        await _repo.AddAsync(user);
        await _repo.SaveChangesAsync();
        //do we really need 2 seperate calls here?
        return user;
    }

    public async Task<User?> LoginAsync(string email, string password)
    {
        var user = await _repo.FindByEmailAsync(email);
        if (user == null)
        {
            return null;
        }
        
        var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, password);
        
        if(result == PasswordVerificationResult.Success)
        {
            return user;
        }
        return null;
    }
    
}