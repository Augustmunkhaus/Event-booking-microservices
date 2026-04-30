using EventTix.Identity.Domain;

namespace EventTix.Identity.Infrastructure;

public interface IUserRepository
{
    Task<bool> EmailExistsAsync(string email);
    Task AddAsync(User user);
    Task SaveChangesAsync();
    
    Task<User?> FindByEmailAsync(string email);
}