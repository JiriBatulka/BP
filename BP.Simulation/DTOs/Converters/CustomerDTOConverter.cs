using BP.Models;
using BP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.DTOs.Converters
{
    public class CustomerDTOConverter
    {
        private readonly DecryptionService _decryptionService;

        public CustomerDTOConverter(DecryptionService decryptionService)
        {
            _decryptionService = decryptionService;
        }

        public CustomerDTO.AddCustomerDTO Convert(Customer customer)
        {
            return new CustomerDTO.AddCustomerDTO()
            {
                ApiPassword = "h&!EvEZTGc-p@F9P",
                Email = customer.Email,
                EncryptedPassword = _decryptionService.Encrypt(customer.Password),
                FirstName = customer.FirstName,
                PhoneNumber = customer.PhoneNumber,
                Surname = customer.Surname,
                Username = customer.Username
            };
        }
    }
}
