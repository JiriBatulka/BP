using System;
using System.Collections.Generic;

namespace BP.Models
{
    public class VehicleRent
    {
        public Guid VehicleRentId { get; set; }
        public Guid VehicleId { get; set; }
        public Guid DriverId { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeUntil { get; set; }
    }
}
