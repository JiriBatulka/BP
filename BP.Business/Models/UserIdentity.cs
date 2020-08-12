using BP.Enums;
using System;

namespace BP.Models
{
    public class UserIdentity
    {
        public Guid UserIdentityID { get; set; }
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }
        public string DecryptedPassword { get; set; }
        public byte[] PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public RoleEnum Role { get; set; }
    }
}
