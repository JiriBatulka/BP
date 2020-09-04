using BP.Enums;
using System;

namespace BP.Models
{
    public class UserIdentity
    {
        public Guid UserIdentityID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public RoleEnum Role { get; set; }
    }
}
