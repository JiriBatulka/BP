using BP.Simulation.Models;
using BP.Simulation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.Simulation.DTOs.Converters
{
    public class UserDTOConverter
    {
        private readonly DecryptionService _decryptionService;

        public UserDTOConverter(DecryptionService decryptionService)
        {
            _decryptionService = decryptionService;
        }
        internal UserDTO.GetAuthTokenDTO Convert(User user)
        {
            return new UserDTO.GetAuthTokenDTO()
            {
                EncryptedPassword = _decryptionService.Encrypt(user.Password),
                Username = user.Username
            };
        }
    }
}
