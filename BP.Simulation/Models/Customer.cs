using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.Models
{
    public class Customer : User
    {
        public double? CurrentLat { get; set; }
        public double? CurrentLng { get; set; }
    }
}
