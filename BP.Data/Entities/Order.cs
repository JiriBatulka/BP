using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BP.Entities
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime VehicleArriveEstimate { get; set; }
        public DateTime? EndTimeEstimate { get; set; }
        public double StartLocationLat { get; set; }
        public double StartLocationLng { get; set; }
        public double? EndLocationLat { get; set; }
        public double? EndLocationLng { get; set; }
        public bool IsActive { get; set; }

        public Guid CustomerID { get; set; }
        public Customer Customer { get; set; }
        public Guid VehicleID { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
