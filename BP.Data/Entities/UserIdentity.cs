using System;
using System.Collections.Generic;

namespace BP.Entities
{
    public class UserIdentity
    {
        public Guid UserIdentityID { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Role { get; set; }

        public List<Driver> Drivers { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
