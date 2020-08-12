using System;
using System.Collections.Generic;

namespace BP.Entities
{
    public class Vehicle
    {
        public Guid VehicleID { get; set; }
        public string Type { get; set; }
        public string NumberPlate { get; set; }
        public string Colour { get; set; }
        public int AdultSeats { get; set; }
        public int InfantSeats { get; set; }
        public int BootCapacity { get; set; }
        public double? CurrentLat { get; set; }
        public double? CurrentLng { get; set; }
        public bool IsShared { get; set; }
        public bool? IsActive { get; set; }

        public List<VehicleRent> VehicleRents { get; set; }
        public List<Order> Orders { get; set; }
    }
}
