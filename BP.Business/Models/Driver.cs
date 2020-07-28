using System;
using System.Collections.Generic;

namespace BP.Models
{
    public class Driver : UserIdentity
    {
        public Guid DriverID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public bool? IsActive { get; set; }
    }
}
