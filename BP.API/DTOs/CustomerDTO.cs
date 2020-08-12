using System;
using System.ComponentModel.DataAnnotations;

namespace BP.DTOs
{
    public class CustomerDTO
    {
        public class AddCustomerDTO
        {
            [Required, StringLength(255)]
            public string Surname { get; set; }
            [Required, StringLength(255)]
            public string FirstName { get; set; }
            [Required, StringLength(255)]
            public string PhoneNumber { get; set; }
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
            [Required, StringLength(255)]
            public string Username { get; set; }
            [Required]
            public string EncryptedPassword { get; set; }
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
