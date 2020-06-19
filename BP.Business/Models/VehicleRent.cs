using System;
using System.Collections.Generic;

namespace BP.Models
{
    public class VehicleRent
    {
        public Guid VehicleRentID { get; set; }
        public Guid VehicleID { get; set; }
        public Guid DriverID { get; set; }
        public DateTime? TimeFrom { get; set; }
        public DateTime? TimeUntil { get; set; }
        public bool IsOwned { get; set; }
    }
}
