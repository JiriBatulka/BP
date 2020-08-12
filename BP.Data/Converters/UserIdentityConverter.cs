using BP.Entities;
using BP.Enums;
using System;

namespace BP.Converters
{
    public class UserIdentityConverter
    {
        public Entities.UserIdentity Convert(Models.UserIdentity userIdentity)
        {
            return new UserIdentity
            {
                PasswordHash = userIdentity.PasswordHash,
                PasswordSalt = userIdentity.PasswordSalt,
                Role = userIdentity.Role.ToString(),
                UserIdentityID = userIdentity.UserIdentityID,
                Username = userIdentity.Username
            };
        }

        public Models.UserIdentity Convert(Entities.UserIdentity userIdentity)
        {
            Models.UserIdentity result =  new Models.UserIdentity
            {
                PasswordHash = userIdentity.PasswordHash,
                PasswordSalt = userIdentity.PasswordSalt,
                UserIdentityID = userIdentity.UserIdentityID,
                Username = userIdentity.Username,
            };
            Enum.TryParse(userIdentity.Role, out RoleEnum role);
            result.Role = role;
            return result;
        }
    }
}
