using BP.Simulation.Models;
using BP.Simulation.Services;
using System.Collections.Generic;
using System.Linq;

namespace BP.Simulation.DTOs.Converters
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
                Email = customer.Email,
                EncryptedPassword = _decryptionService.Encrypt(customer.Password),
                FirstName = customer.FirstName,
                PhoneNumber = customer.PhoneNumber,
                Surname = customer.Surname,
                Username = customer.Username
            };
        }

        public Customer Convert(CustomerDTO.GetCustomersDTO customer)
        {
            return new Customer()
            {
                CurrentLat = customer.CurrentLat,
                CurrentLng = customer.CurrentLng,
                Email = customer.Email,
                FirstName = customer.FirstName,
                IsActive = customer.IsActive,
                PhoneNumber = customer.PhoneNumber,
                Role = Enums.RoleEnum.Customer,
                Surname = customer.Surname,
                Password = $"{customer.FirstName}+{customer.Surname}@123",
                Username = $"{customer.FirstName[0]}.{customer.Surname}".ToLower()
            };
        }

        public IEnumerable<Customer> Convert(IEnumerable<CustomerDTO.GetCustomersDTO> customers)
        {
            return customers.Select(x => Convert(x));
        }
    }
}
