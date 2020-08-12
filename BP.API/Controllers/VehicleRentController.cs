using System.Threading.Tasks;
using BP.ApiRepositories.Interfaces;
using BP.Converters;
using BP.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BP.Controllers
{
    [Produces("application/json")]
    [Route("api/vehiclerent")]
    [ApiController]
    public class VehicleRentController : ControllerBase
    {
        private readonly IApiVehicleRentRepository _vehicleRentRepository;
        private readonly VehicleRentDTOConverter _vehicleRentDTOConverter;

        public VehicleRentController(IApiVehicleRentRepository vehicleRentRepository, VehicleRentDTOConverter vehicleRentDTOConverter)
        {
            _vehicleRentRepository = vehicleRentRepository;
            _vehicleRentDTOConverter = vehicleRentDTOConverter;
        }

        [HttpGet("add")]
        public async Task<IActionResult> AddVehicleAsync([FromBody] VehicleRentDTO.AddVehicleRentDTO value)
        {
            try
            {
                await _vehicleRentRepository.AddVehicleRentAsync(_vehicleRentDTOConverter.Convert(value));
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
