using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.DTOs
{
    public class CustomerDTO
    {
        public class AddCustomerDTO
        {
            public string Surname { get; set; }
            public string FirstName { get; set; }
        }

        public class MoveCustomerDTO
        {
            public Guid CustomerID { get; set; }
            public double TargetLat { get; set; }
            public double TargetLng { get; set; }
        }
    }
}
