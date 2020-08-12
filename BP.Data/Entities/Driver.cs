using System;
using System.Collections.Generic;

namespace BP.Entities
{
    public class Driver
    {
        public Guid DriverID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Guid UserIdentityID { get; set; }
        public UserIdentity UserIdentity { get; set; }

        public List<VehicleRent> VehicleRents { get; set; }
    }
}
