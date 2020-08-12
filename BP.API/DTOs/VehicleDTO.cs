using System;
using System.ComponentModel.DataAnnotations;

namespace BP.DTOs
{
    public class VehicleDTO
    {
        public class AddVehicleDTO
        {
            [Required, StringLength(255)]
            public string Type { get; set; }
            [Required, StringLength(255)]
            public string NumberPlate { get; set; }
            [Required, StringLength(255)]
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
