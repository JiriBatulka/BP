using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.DTOs
{
    public class VehicleDTO
    {
        public class AddVehicleDTO
        {
            public string Type { get; set; }
            public string NumberPlate { get; set; }
            public string Colour { get; set; }
            public int AdultSeats { get; set; }
            public int InfantSeats { get; set; }
            public int BootCapacity { get; set; }
            public bool IsShared { get; set; }
        }

        public class MoveVehicleDTO
        {
            public Guid VehicleID { get; set; }
            public double TargetLat { get; set; }
            public double TargetLng { get; set; }
        }
    }
}
