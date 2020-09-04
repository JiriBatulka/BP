using BP.DTOs;
using BP.Models;
using BP.Services;

namespace BP.Converters
{
    public class UserIdentityDTOConverter
    {
        private readonly DecryptionService _decryptionService;

        public UserIdentityDTOConverter(DecryptionService decryptionService)
        {
            _decryptionService = decryptionService;
        }

        public UserIdentity Convert(UserIdentityDTO.GetAuthTokenDTO getAuthTokenDTO)
        {
            return new UserIdentity
            {
                Password = _decryptionService.Decrypt(getAuthTokenDTO.EncryptedPassword),
                Username = getAuthTokenDTO.Username
            };
        }
    }
}
