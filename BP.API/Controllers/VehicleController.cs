using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BP.ApiRepositories.Interfaces;
using BP.Converters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BP.DTOs;

namespace BP.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IApiVehicleRepository vehicleRepository;
        private readonly VehicleDTOConverter vehicleDTOConverter;

        public VehicleController(IApiVehicleRepository vehicleRepository, VehicleDTOConverter vehicleDTOConverter)
        {
            this.vehicleRepository = vehicleRepository;
            this.vehicleDTOConverter = vehicleDTOConverter;
        }

        [HttpGet("add")]
        public async Task<IActionResult> AddVehicleAsync([FromBody] VehicleDTO.AddVehicleDTO value)
        {
            try
            {
                return Ok(await vehicleRepository.AddVehicleAsync(vehicleDTOConverter.Convert(value)));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("move")]
        public async Task<IActionResult> MoveVehicleAsync([FromBody] VehicleDTO.MoveVehicleDTO value)
        {
            try
            {
                await vehicleRepository.MoveVehicleAsync(vehicleDTOConverter.Convert(value));
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
