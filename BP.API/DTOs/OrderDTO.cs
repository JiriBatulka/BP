using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BP.DTOs
{
    public class OrderDTO
    {
        public class AddOrderDTO
        {
            [Required]
            public Guid CustomerID { get; set; }
            [Required]
            public DateTime StartTime { get; set; }
            [Required]
            public double StartLocationLat { get; set; }
            [Required]
            public double StartLocationLng { get; set; }
            public double? EndLocationLat { get; set; }
            public double? EndLocationLng { get; set; }
        }
    }
}
