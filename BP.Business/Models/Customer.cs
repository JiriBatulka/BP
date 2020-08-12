using System;

namespace BP.Models
{
    public class Customer : User
    {
        public Guid CustomerID { get; set; }
        public double? CurrentLat { get; set; }
        public double? CurrentLng { get; set; }
    }
}
