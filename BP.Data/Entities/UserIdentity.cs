using BP.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Entities
{
    public class UserIdentity
    {
        public Guid UserIdentityID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public RoleEnum Role { get; set; }
    }
}
