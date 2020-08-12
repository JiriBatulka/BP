using BP.DTOs;
using BP.Models;

namespace BP.Converters
{
    public class UserIdentityDTOConverter
    {
        public UserIdentity Convert(UserIdentityDTO.CheckUserIdentityDTO checkUserIdentityDTO)
        {
            return new UserIdentity
            {
                EncryptedPassword = checkUserIdentityDTO.EncryptedPassword,
                Username = checkUserIdentityDTO.Username
            };
        }
    }
}
