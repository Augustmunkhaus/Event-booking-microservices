using EventTix.Identity.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventTix.Identity.Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly IdentityDbContext _db;

    public UserRepository(IdentityDbContext db) => _db = db;

    public Task<bool> EmailExistsAsync(string email)
    {
       return _db.Users.AnyAsync(u => u.Email == email);
    }
        

    public async Task AddAsync(User user)
    {
        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();
    }
        
    
    public Task<User?> FindByEmailAsync(string email)
    {
       return _db.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
        
}
