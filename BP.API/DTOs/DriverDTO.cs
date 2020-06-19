using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BP.DTOs
{
    public class DriverDTO
    {
        public class AddDriverDTO
        {
            public string Surname { get; set; }
            public string FirstName { get; set; }
        }
    }
}
