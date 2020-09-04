using BP.Models;

namespace BP.Converters
{
    public class UserConverter
    {
        public User Convert(UserIdentity userIdentity)
        {
            return new User
            {
                PasswordHash = userIdentity.PasswordHash,
                PasswordSalt = userIdentity.PasswordSalt,
                UserIdentityID = userIdentity.UserIdentityID,
                Username = userIdentity.Username,
                Role = userIdentity.Role,
                ApiPassword = userIdentity.ApiPassword,
                Password = userIdentity.Password,
            };
        }
    }
}
