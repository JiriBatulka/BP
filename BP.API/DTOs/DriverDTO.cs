using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            [Required]
            public string Surname { get; set; }
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string PhoneNumber { get; set; }
        }
    }
}
