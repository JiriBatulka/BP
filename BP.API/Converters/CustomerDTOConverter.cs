using BP.Models;
using static BP.DTOs.CustomerDTO;

namespace BP.Converters
{
    public class CustomerDTOConverter
    {
        public Customer Convert(AddCustomerDTO addCustomerDTO)
        {
            return new Customer
            {
                FirstName = addCustomerDTO.FirstName,
                Surname = addCustomerDTO.Surname,
                PhoneNumber = addCustomerDTO.PhoneNumber,
                Email = addCustomerDTO.Email,
                EncryptedPassword = addCustomerDTO.EncryptedPassword,
                Username = addCustomerDTO.Username
            };
        }

        public Customer Convert(MoveCustomerDTO moveCustomerDTO)
        {
            return new Customer
            {
                CustomerID = moveCustomerDTO.CustomerID,
                CurrentLat = moveCustomerDTO.TargetLat,
                CurrentLng = moveCustomerDTO.TargetLng,
            };
        }
    }
}
