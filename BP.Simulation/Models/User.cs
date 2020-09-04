using BP.Enums;
using System;

namespace BP.Simulation.Models
{
    public class User
    {
        public Guid UserIdentityID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public RoleEnum Role { get; set; }
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public bool? IsActive { get; set; }
        public string Email { get; set; }
        public string AuthToken { get; set; }
    }
}
