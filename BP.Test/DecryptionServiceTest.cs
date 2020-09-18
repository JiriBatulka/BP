using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using BP.Services;
using Moq;
using System.Security.Cryptography;

namespace BP
{
    public class DecryptionServiceTest
    {
        private readonly DecryptionService _decryptionService;
        public DecryptionServiceTest()
        {
            Mock<BusinessSettings> businessSettings = new Mock<BusinessSettings>();
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            businessSettings.SetupGet(x => x.PrivateEncryptionKey).Returns(rsa.ToXmlString(true));
            businessSettings.SetupGet(x => x.PublicEncryptionKey).Returns(rsa.ToXmlString(false));
            _decryptionService = new DecryptionService(businessSettings.Object);
        }

        [Fact]
        public void EncryptDecrypt_ShouldWork()
        {
            string password = "Test123@";

            string encryptedPassword = _decryptionService.Encrypt(password);

            Assert.NotEqual(password, encryptedPassword);

            string decryptedPassword = _decryptionService.Decrypt(encryptedPassword);

            Assert.Equal(password, decryptedPassword);
        }
    }
}
