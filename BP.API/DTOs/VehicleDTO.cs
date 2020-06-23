using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BP.DTOs
{
    public class VehicleDTO
    {
        public class AddVehicleDTO
        {
            [Required]
            public string Type { get; set; }
            [Required]
            public string NumberPlate { get; set; }
            [Required]
            public string Colour { get; set; }
            [Required]
            public int AdultSeats { get; set; }
            [Required]
            public int InfantSeats { get; set; }
            [Required]
            public int BootCapacity { get; set; }
            [Required]
            public bool IsShared { get; set; }
        }

        public class MoveVehicleDTO
        {
            [Required]
            public Guid VehicleID { get; set; }
            [Required]
            public double TargetLat { get; set; }
            [Required]
            public double TargetLng { get; set; }
        }
    }
}
