using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BP.ApiRepositories.Interfaces;
using BP.Converters;
using BP.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BP.Controllers
{
    [Route("api/driver")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IApiDriverRepository driverRepository;
        private readonly DriverDTOConverter driverDTOConverter;

        public DriverController(IApiDriverRepository driverRepository, DriverDTOConverter driverDTOConverter)
        {
            this.driverRepository = driverRepository;
            this.driverDTOConverter = driverDTOConverter;
        }

        [HttpGet("add")]
        public async Task<Guid> AddDriverAsync([FromBody] DriverDTO.AddDriverDTO value)
        {
            return await driverRepository.AddDriverAsync(driverDTOConverter.Convert(value));
        }
    }
}
