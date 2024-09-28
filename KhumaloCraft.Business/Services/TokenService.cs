using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using KhumaloCraft.Business.Interfaces;
using Microsoft.Extensions.Configuration;

namespace KhumaloCraft.Business.Services
{
  public class TokenService : ITokenService
  {
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public string GenerateToken(string userId, string email, string firstName, string lastName)
    {
      // Define the claims that will be stored in the JWT token
      var claims = new[]
      {
          new Claim(JwtRegisteredClaimNames.Sub, email),
          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
          new Claim(ClaimTypes.NameIdentifier, userId),
          new Claim(ClaimTypes.Name, email),
          new Claim(ClaimTypes.GivenName, firstName),
          new Claim(ClaimTypes.Surname, lastName)
      };

      // Get the secret key from appsettings.json
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      // Create the JWT token
      var token = new JwtSecurityToken(
          issuer: _configuration["Jwt:Issuer"],
          audience: _configuration["Jwt:Audience"],
          claims: claims,
          expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"])),
          signingCredentials: creds
      );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}
