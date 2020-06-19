using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BP.Entities
{
    public class Driver
    {
        public Guid DriverID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        public List<VehicleRent> VehicleRents { get; set; }
    }
}
