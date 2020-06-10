using System;
using System.Collections.Generic;

namespace BP.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid ClientId { get; set; }
        public Guid VehicleId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTimeEstimate { get; set; }
        public double StartLocationLat { get; set; }
        public double StartLocationLng { get; set; }
        public double? EndLocationLat { get; set; }
        public double? EndLocationLng { get; set; }
    }
}
