using System;
using System.Collections.Generic;

namespace BP.Entities
{
    public class Customer
    {
        public Guid CustomerID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public double? CurrentLat { get; set; }
        public double? CurrentLng { get; set; }
        public bool? IsActive { get; set; }

        public Guid UserIdentityID { get; set; }
        public UserIdentity UserIdentity { get; set; }

        public List<Order> Orders { get; set; }
    }
}
