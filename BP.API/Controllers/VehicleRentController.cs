using System;
using System.Threading.Tasks;
using BP.Converters;
using BP.DTOs;
using BP.ModelRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BP.Controllers
{
    [Produces("application/json")]
    [Route("api/vehiclerent")]
    [Authorize(Roles = "Driver")]
    [ApiController]
    public class VehicleRentController : ControllerBase
    {
        private readonly VehicleRentModelRepository _vehicleRentModelRepository;
        private readonly VehicleRentDTOConverter _vehicleRentDTOConverter;
        private readonly CustomLogger _logger;

        public VehicleRentController(VehicleRentModelRepository vehicleRentModelRepository, VehicleRentDTOConverter vehicleRentDTOConverter, CustomLogger logger)
        {
            _vehicleRentModelRepository = vehicleRentModelRepository;
            _vehicleRentDTOConverter = vehicleRentDTOConverter;
            _logger = logger;
        }

        [HttpGet("add")]
        public async Task<IActionResult> AddVehicleAsync([FromBody] VehicleRentDTO.AddVehicleRentDTO value)
        {
            try
            {
                await _vehicleRentModelRepository.AddVehicleRentAsync(_vehicleRentDTOConverter.Convert(value));
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogApiException(ex);
                return StatusCode(500);
            }
        }
    }
}
