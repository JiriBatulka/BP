using System;
using System.Collections.Generic;

namespace BP.Models
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public Guid CustomerID { get; set; }
        public Guid VehicleID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime VehicleArriveEstimate { get; set; }
        public DateTime? EndTimeEstimate { get; set; }
        public double StartLocationLat { get; set; }
        public double StartLocationLng { get; set; }
        public double? EndLocationLat { get; set; }
        public double? EndLocationLng { get; set; }
        public bool IsActive { get; set; }
    }
}
