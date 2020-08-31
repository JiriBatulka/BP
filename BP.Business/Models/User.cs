using System;

namespace BP.Models
{
    public class User : UserIdentity
    {
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public bool? IsActive { get; set; }
        public string Email { get; set; }
    }
}
