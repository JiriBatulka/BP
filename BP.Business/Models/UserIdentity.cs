using BP.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Models
{
    public class UserIdentity
    {
        public Guid UserIdentityID { get; set; }
        public string Username { get; set; }
        public string PasswordEcrypted { get; set; }
        public string PasswordDecrypted { get; set; }
        public RoleEnum Role { get; set; }
    }
}
