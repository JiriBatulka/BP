using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.Simulation.DTOs
{
    public class UserDTO
    {
        public class GetAuthTokenDTO
        {
            public string Username { get; set; }
            public string EncryptedPassword { get; set; }
        }
    }
}
