using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BP.DTOs
{
    public class CustomerDTO
    {
        public class AddCustomerDTO
        {
            [Required]
            public string Surname { get; set; }
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string PhoneNumber { get; set; }
        }

        public class MoveCustomerDTO
        {
            [Required]
            public Guid CustomerID { get; set; }
            [Required]
            public double TargetLat { get; set; }
            [Required]
            public double TargetLng { get; set; }
        }
    }
}
