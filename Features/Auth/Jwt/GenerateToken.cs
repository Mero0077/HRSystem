using HRSystem.Common.Constants;
using HRSystem.Features.Auth.Jwt.Helper;
using HRSystem.Features.Auth.Jwt.interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HRSystem.Features.Auth.Jwt
{
    public class GenerateToken : IJwtGenerateHandler
    {
        private readonly JwtOptions options;

        public GenerateToken(IOptions<JwtOptions> options)
        {
            this.options = options.Value;
        }
        string IJwtGenerateHandler.GenerateToken(string userName, Guid userId, List<Guid> roleIds,Guid organizationId)
        {
            var encodedSecretKey = JwtHelper.GetSymmetricSecurityKey();
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = new List<Claim>
          {
              new Claim(ClaimTypes.NameIdentifier,userId.ToString()),
              new Claim(ClaimTypes.Name,userName),
              new Claim("OrganizationId",organizationId.ToString())
          };

            foreach (var roleId in roleIds)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleId.ToString()));
            }

            var creds = new SigningCredentials(encodedSecretKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = options.Issuer,
                Audience = options.Audience,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(Constants.JwtExpiredAcessTokenHours),
                NotBefore = DateTime.UtcNow,
                SigningCredentials = creds
            };
         var token = tokenHandler.CreateToken(tokenDescriptor);
         return tokenHandler.WriteToken(token);
    }
 }
}