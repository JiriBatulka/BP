using BP.DTOs;
using BP.Models;

namespace BP.Converters
{
    public class DriverDTOConverter
    {
        public Driver Convert(DriverDTO.AddDriverDTO addDriverDTO)
        {
            return new Driver
            {
                FirstName = addDriverDTO.FirstName,
                Surname = addDriverDTO.Surname,
                PhoneNumber = addDriverDTO.PhoneNumber,
                Email = addDriverDTO.Email
            };
        }
    }
}
