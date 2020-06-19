using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.DTOs
{
    public class VehicleRentDTO
    {
        public class AddVehicleRentDTO
        {
            public DateTime? TimeFrom { get; set; }
            public DateTime? TimeUntil { get; set; }
            public bool IsOwned { get; set; }
            public Guid VehicleID { get; set; }
            public Guid DriverID { get; set; }
        }
    }
}
