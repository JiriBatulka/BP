using BP.DTOs;
using BP.Models;
using BP.Services;

namespace BP.Converters
{
    public class DriverDTOConverter
    {
        private readonly DecryptionService _decryptionService;

        public DriverDTOConverter(DecryptionService decryptionService)
        {
            _decryptionService = decryptionService;
        }

        public Driver Convert(DriverDTO.AddDriverDTO addDriverDTO)
        {
            return new Driver
            {
                FirstName = addDriverDTO.FirstName,
                Surname = addDriverDTO.Surname,
                PhoneNumber = addDriverDTO.PhoneNumber,
                Email = addDriverDTO.Email,
                Password = _decryptionService.Decrypt(addDriverDTO.EncryptedPassword),
                Username = addDriverDTO.Username
            };
        }
    }
}
