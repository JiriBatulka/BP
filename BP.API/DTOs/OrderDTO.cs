using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.DTOs
{
    public class OrderDTO
    {
        public class AddOrderDTO
        {
            public Guid CustomerID { get; set; }
            public DateTime StartTime { get; set; }
            public double StartLocationLat { get; set; }
            public double StartLocationLng { get; set; }
            public double? EndLocationLat { get; set; }
            public double? EndLocationLng { get; set; }
        }
    }
}
