using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BP.Services
{
    public class DecryptionService
    {
        private readonly BusinessSettings _businessSettings;

        public DecryptionService(BusinessSettings businessSettings)
        {
            _businessSettings = businessSettings;
        }

        public string Encrypt(string decryptedPassword)
        {
            using var rsa = new RSACryptoServiceProvider(1024);
            try
            {
                byte[] dataToEncrypt = Encoding.UTF8.GetBytes(decryptedPassword);
                rsa.FromXmlString(_businessSettings.PublicEncryptionKey);
                byte[] encryptedData = rsa.Encrypt(dataToEncrypt, true);
                return Convert.ToBase64String(encryptedData);
            }
            finally
            {
                rsa.PersistKeyInCsp = false;
            }
        }

        public string Decrypt(string encryptedPassword)
        {
            using RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);
            try
            {
                byte[] dataToDecrypt = Convert.FromBase64String(encryptedPassword);
                rsa.FromXmlString(_businessSettings.PrivateEncryptionKey);
                byte[] decryptedData = rsa.Decrypt(dataToDecrypt, true);
                return Encoding.UTF8.GetString(decryptedData);
            }
            finally
            {
                rsa.PersistKeyInCsp = false;
            }
        }

        public byte[] Hash(string password, string salt)
        {
            using SHA256 sha256Hash = SHA256.Create();
            return sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
        }
    }
}
