using System;
using System.Collections.Generic;

namespace BP.Models
{
    public class Vehicle
    {
        public Guid VehicleId { get; set; }
        public string Type { get; set; }
        public string Spz { get; set; }
        public string Colour { get; set; }
        public int AdultSeats { get; set; }
        public int InfantSeats { get; set; }
        public int BootCapacity { get; set; }
        public double? CurrentLat { get; set; }
        public double? CurrentLng { get; set; }
        public bool? IsShared { get; set; }
        public Guid? DriverId { get; set; }
    }
}
