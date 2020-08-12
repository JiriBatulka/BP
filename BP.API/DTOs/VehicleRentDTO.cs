using System;
using System.ComponentModel.DataAnnotations;

namespace BP.DTOs
{
    public class VehicleRentDTO
    {
        public class AddVehicleRentDTO
        {
            public DateTime? TimeFrom { get; set; }
            public DateTime? TimeUntil { get; set; }
            [Required]
            public bool IsOwned { get; set; }
            [Required]
            public Guid VehicleID { get; set; }
            [Required]
            public Guid DriverID { get; set; }
        }
    }
}
