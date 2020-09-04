using BP.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BP.Services
{
    public class AuthenticationService
    {
        private readonly BusinessSettings _businessSettings;
        private readonly DecryptionService _decryptionService;

        public AuthenticationService(BusinessSettings businessSettings, DecryptionService decryptionService)
        {
            _businessSettings = businessSettings;
            _decryptionService = decryptionService;
        }

        public string GetToken(User userIdentity)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_businessSettings.JwtSecret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userIdentity.UserIdentityID.ToString()),
                    new Claim(ClaimTypes.Name, userIdentity.UserID.ToString()),
                    new Claim(ClaimTypes.Role, userIdentity.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool IsValidPassword(string password, string dbSalt, byte[] dbHash)
        {
            byte[] comparedHash = _decryptionService.Hash(password, dbSalt);
            if (comparedHash.SequenceEqual(dbHash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
