using System.Threading.Tasks;
using BP.Converters;
using Microsoft.AspNetCore.Mvc;
using BP.DTOs;
using Microsoft.AspNetCore.Authorization;
using System;
using BP.ModelRepositories;

namespace BP.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(Roles = "Driver")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleModelRepository _vehicleModelRepository;
        private readonly VehicleDTOConverter _vehicleDTOConverter;
        private readonly CustomLogger _logger;

        public VehicleController(VehicleModelRepository vehicleModelRepository, VehicleDTOConverter vehicleDTOConverter, CustomLogger logger)
        {
            _vehicleModelRepository = vehicleModelRepository;
            _vehicleDTOConverter = vehicleDTOConverter;
            _logger = logger;
        }

        [HttpGet("add")]
        public async Task<IActionResult> AddVehicleAsync([FromBody] VehicleDTO.AddVehicleDTO value)
        {
            try
            {
                await _vehicleModelRepository.AddVehicleAsync(_vehicleDTOConverter.Convert(value));
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
                await _vehicleModelRepository.MoveVehicleAsync(_vehicleDTOConverter.Convert(value));
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
