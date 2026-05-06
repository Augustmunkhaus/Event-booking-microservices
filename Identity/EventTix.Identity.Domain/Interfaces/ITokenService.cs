namespace EventTix.Identity.Domain;

public interface ITokenService
{
    string CreateToken(User user);
}