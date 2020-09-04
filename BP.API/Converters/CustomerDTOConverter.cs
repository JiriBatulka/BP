using BP.Models;
using BP.Services;
using System.Collections.Generic;
using System.Linq;
using static BP.DTOs.CustomerDTO;

namespace BP.Converters
{
    public class CustomerDTOConverter
    {
        private readonly DecryptionService _decryptionService;

        public CustomerDTOConverter(DecryptionService decryptionService)
        {
            _decryptionService = decryptionService;
        }

        public Customer Convert(AddCustomerDTO addCustomerDTO)
        {
            return new Customer
            {
                FirstName = addCustomerDTO.FirstName,
                Surname = addCustomerDTO.Surname,
                PhoneNumber = addCustomerDTO.PhoneNumber,
                Email = addCustomerDTO.Email,
                Password = _decryptionService.Decrypt(addCustomerDTO.EncryptedPassword),
                Username = addCustomerDTO.Username
            };
        }

        public Customer Convert(MoveCustomerDTO moveCustomerDTO)
        {
            return new Customer
            {
                CurrentLat = moveCustomerDTO.TargetLat,
                CurrentLng = moveCustomerDTO.TargetLng,
            };
        }

        public GetCustomersDTO Convert(Customer customer)
        {
            return new GetCustomersDTO()
            {
                CurrentLat = customer.CurrentLat,
                CurrentLng = customer.CurrentLng,
                Email = customer.Email,
                FirstName = customer.FirstName,
                IsActive = customer.IsActive,
                PhoneNumber = customer.PhoneNumber,
                Surname = customer.Surname
            };
        }

        public IEnumerable<GetCustomersDTO> Convert(IEnumerable<Customer> customers)
        {
            return customers.Select(x => Convert(x));
        }
    }
}
