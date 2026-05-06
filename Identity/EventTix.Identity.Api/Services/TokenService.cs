using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EventTix.Identity.Domain;
using Microsoft.IdentityModel.Tokens;

namespace EventTix.Identity.Api.Services;

public class TokenService : ITokenService
{   
    //get access to JWT section in appsettings.JSON
    private readonly IConfiguration _config;
    
    public TokenService(IConfiguration config) => _config = config;

    public string CreateToken(User user)
    {
        var jwt = _config.GetSection("Jwt");
        
        // Convert secret string to bytes — required by SymmetricSecurityKey
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!));
        
        // The "seal recipe": the stamp (key) + the technique used to press it (HmacSha256).
        // Other services use this same recipe to verify the seal is genuine.
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        // Claims = facts about the user, written inside the token. other services read these.
        
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        
        // Assemble the token: header + payload + signature
        var token = new JwtSecurityToken(
            issuer: jwt["Issuer"],
            audience: jwt["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(int.Parse(jwt["ExpiryMinutes"]!)),
            signingCredentials: creds
        );
        
        // Serialize to the compact "header.payload.signature" string
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}