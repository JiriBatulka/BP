using System;
using System.Collections.Generic;

namespace BP.Entities
{
    public partial class Driver
    {
        public Driver()
        {
            VehicleRent = new HashSet<VehicleRent>();
        }

        public Guid DriverId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<VehicleRent> VehicleRent { get; set; }
    }
}
