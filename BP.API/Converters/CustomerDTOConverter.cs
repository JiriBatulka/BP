using BP.Models;
using BP.Services;
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
                Username = addCustomerDTO.Username,
                ApiPassword = addCustomerDTO.ApiPassword
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
    }
}
