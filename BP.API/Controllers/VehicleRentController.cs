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
    [Route("api/vehiclerent")]
    [ApiController]
    public class VehicleRentController : ControllerBase
    {
        private readonly IApiVehicleRentRepository vehicleRentRepository;
        private readonly VehicleRentDTOConverter vehicleRentDTOConverter;

        public VehicleRentController(IApiVehicleRentRepository vehicleRentRepository, VehicleRentDTOConverter vehicleRentDTOConverter)
        {
            this.vehicleRentRepository = vehicleRentRepository;
            this.vehicleRentDTOConverter = vehicleRentDTOConverter;
        }

        [HttpGet("add")]
        public async Task<IActionResult> AddVehicleAsync([FromBody] VehicleRentDTO.AddVehicleRentDTO value)
        {
            try
            { 
            return Ok(await vehicleRentRepository.AddVehicleRentAsync(vehicleRentDTOConverter.Convert(value)));
        }
            catch
            {
                return StatusCode(500);
    }
}
    }
}
