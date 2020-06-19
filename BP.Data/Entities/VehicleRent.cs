using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BP.Entities
{
    public class VehicleRent
    {
        public Guid VehicleRentID { get; set; }
        public DateTime? TimeFrom { get; set; }
        public DateTime? TimeUntil { get; set; }
        public bool IsOwned { get; set; }

        public Guid VehicleID { get; set; }
        public Vehicle Vehicle { get; set; }
        public Guid DriverID { get; set; }
        public Driver Driver { get; set; }
    }
}
