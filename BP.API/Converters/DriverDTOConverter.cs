using BP.DTOs;
using BP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                PhoneNumber = addDriverDTO.PhoneNumber
            };
        }
    }
}
