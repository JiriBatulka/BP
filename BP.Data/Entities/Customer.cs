using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BP.Entities
{
    public class Customer
    {
        public Guid CustomerID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public double? CurrentLat { get; set; }
        public double? CurrentLng { get; set; }
        public bool? IsActive { get; set; }

        public List<Order> Orders { get; set; }
    }
}
