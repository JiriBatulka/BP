using System.Threading.Tasks;
using BP.ApiRepositories.Interfaces;
using BP.Converters;
using Microsoft.AspNetCore.Mvc;
using BP.DTOs;

namespace BP.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IApiVehicleRepository _vehicleRepository;
        private readonly VehicleDTOConverter _vehicleDTOConverter;

        public VehicleController(IApiVehicleRepository vehicleRepository, VehicleDTOConverter vehicleDTOConverter)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleDTOConverter = vehicleDTOConverter;
        }

        [HttpGet("add")]
        public async Task<IActionResult> AddVehicleAsync([FromBody] VehicleDTO.AddVehicleDTO value)
        {
            try
            {
                await _vehicleRepository.AddVehicleAsync(_vehicleDTOConverter.Convert(value));
                return Ok();
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
                await _vehicleRepository.MoveVehicleAsync(_vehicleDTOConverter.Convert(value));
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
