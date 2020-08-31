using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BP.Services
{
    public class DecryptionService
    {
        public string Encrypt(string decryptedPassword)
        {
            using var rsa = new RSACryptoServiceProvider(1024);
            try
            {
                byte[] dataToEncrypt = Encoding.UTF8.GetBytes(decryptedPassword);
                rsa.FromXmlString("<RSAKeyValue><Modulus>v8bjybJHOTrgRh6y1FVZEPhVJlfPhEO7Iz2aEWMQo3oNqVPpvLwIa5RclB8+mmI0my5aW0ujRdqh9CgMCuI6hZE2kakieqT2eSfDqIXRlC1/AGoqLYBeaXrTSsxdHzGjNVeWheFPJQzEMPl3q8GeHTyjqtr87sUbSOzLFr/sl9E=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");
                byte[] encryptedData = rsa.Encrypt(dataToEncrypt, true);
                return Convert.ToBase64String(encryptedData);
            }
            finally
            {
                rsa.PersistKeyInCsp = false;
            }
        }
    }
}
