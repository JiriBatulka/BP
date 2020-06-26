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
    [Produces("application/json")]
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
        public async Task<IActionResult> AddDriverAsync([FromBody] DriverDTO.AddDriverDTO value)
        {
            try
            {
                return Ok(await driverRepository.AddDriverAsync(driverDTOConverter.Convert(value)));
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
