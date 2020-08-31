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
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Username { get; set; }
            public string EncryptedPassword { get; set; }
            public string ApiPassword { get; set; }
        }
    }
}
