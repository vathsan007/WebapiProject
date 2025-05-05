using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebapiProject.Models;

namespace WebapiProject.Authentication
{
    public class Auth : IAuth
    {
        private readonly string key;
        private readonly ApplicationDbContext applicationDbContext;

        public Auth(string key,ApplicationDbContext applicationDbContext)
        {
            this.key = key;
            this.applicationDbContext = applicationDbContext;
        }

        public string GenerateToken(User user)
        {
            // 1. Create Security Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // 2. Create Private Key to Encrypted
            var tokenKey = Encoding.ASCII.GetBytes(key);

            // 3. Create JWTdescriptor
            // 3. Create JWTdescriptor IN AUTH.CS

            var tokenDescriptor = new SecurityTokenDescriptor

            {

                Subject = new ClaimsIdentity(new Claim[]

                {

        new Claim(ClaimTypes.Name, user.Username),

      new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),

       new Claim(ClaimTypes.Role,user.Role)

                }),

                Expires = DateTime.UtcNow.AddHours(1),

                SigningCredentials = new SigningCredentials(

                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)

            };

            // 4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 5. Return Token from method
            return tokenHandler.WriteToken(token);
        }
    }
}
