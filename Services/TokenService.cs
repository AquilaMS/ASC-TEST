using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ASC_TEST.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

namespace ASC_TEST;

public class TokenService
{
    public string Generate(User user)
    {
        var handler = new JwtSecurityTokenHandler();

        var key = Encoding.UTF8.GetBytes(Configs.SecretTokenHash);
        var credential = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor{
            SigningCredentials = credential, 
            Expires = DateTime.UtcNow.AddDays(1),
            Subject = GenerateClaims(user)
        };
        var token = handler.CreateToken(tokenDescriptor);
        var stringToken = handler.WriteToken(token);

        return stringToken;
    }

    private static ClaimsIdentity GenerateClaims(User user){
        var claim = new ClaimsIdentity();
        claim.AddClaim(new Claim(ClaimTypes.Name, user.Name));
        claim.AddClaim(new Claim(ClaimTypes.Email, user.Email));

        return claim;
    }

    public string GetIdTokenExpiry(string idtoken)
{
  var token = new JwtSecurityToken(jwtEncodedString: idtoken);
  string expiry = token.Claims.First(c => c.Type == "expiry").Value;
  return expiry;
}

}
