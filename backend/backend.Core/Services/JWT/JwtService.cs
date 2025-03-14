using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace backend.backend.Core.Services.JWT
{
  public class JwtService
  {
    private readonly string _key;
    private readonly string _issuer;
    private readonly string _audience;

    public JwtService(string key, string issuer, string audience)
    {
      _key = key;
      _issuer = issuer;
      _audience = audience;
    }

    public string GenerateToken(string username, string teacherCode, string role)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_key);

      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.Name, username),
        new Claim("teacherCode", teacherCode),
        new Claim(ClaimTypes.Role, role),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
      };

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.UtcNow.AddHours(1),
        Issuer = _issuer,
        Audience = _audience,
        SigningCredentials = new SigningCredentials(
              new SymmetricSecurityKey(key),
              SecurityAlgorithms.HmacSha256Signature
          )
      };

      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }
  }
}