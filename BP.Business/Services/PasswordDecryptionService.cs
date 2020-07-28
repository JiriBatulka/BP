using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BP.Services
{
    internal class PasswordDecryptionService
    {
        private readonly UnicodeEncoding _byteConverter;
        private readonly BusinessSettings _businessSettings;

        public PasswordDecryptionService(UnicodeEncoding byteConverter, BusinessSettings businessSettings)
        {
            _byteConverter = byteConverter;
            _businessSettings = businessSettings;
        }

        public string Encrypt(string decryptedPassword)
        {
            byte[] dataToEncrypt = _byteConverter.GetBytes(decryptedPassword);
            using RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(_businessSettings.PublicEncryptionKey);
            byte[] encryptedData = rsa.Encrypt(dataToEncrypt, false);
            return _byteConverter.GetString(encryptedData);
        }

        public string Decrypt(string encryptedPassword)
        {
            byte[] dataToDecrypt = _byteConverter.GetBytes(encryptedPassword);
            using RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(_businessSettings.PrivateEncryptionKey);
            byte[] decryptedData = rsa.Decrypt(dataToDecrypt, false);
            return _byteConverter.GetString(decryptedData);
        }
    }
}
