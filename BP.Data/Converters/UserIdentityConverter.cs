using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Converters
{
    public class UserIdentityConverter
    {
        public Entities.UserIdentity Convert(Models.UserIdentity userIdentity)
        {
            return new Entities.UserIdentity
            {
                Password = userIdentity.PasswordEcrypted,
                Role = userIdentity.Role,
                UserIdentityID = userIdentity.UserIdentityID,
                Username = userIdentity.Username
            };
        }
    }
}
