using System;
using System.Threading.Tasks;
using BP.Converters;
using BP.DTOs;
using BP.ModelRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BP.Controllers
{
    [Authorize(Roles = "Driver")]
    [Produces("application/json")]
    [Route("api/driver")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly DriverModelRepository _driverModelRepository;
        private readonly DriverDTOConverter _driverDTOConverter;
        private readonly CustomLogger _logger;

        public DriverController(DriverModelRepository driverModelRepository, DriverDTOConverter driverDTOConverter, CustomLogger logger)
        {
            _driverModelRepository = driverModelRepository;
            _driverDTOConverter = driverDTOConverter;
            _logger = logger;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddDriverAsync([FromBody] DriverDTO.AddDriverDTO value)
        {
            try
            {
                await _driverModelRepository.AddDriverAsync(_driverDTOConverter.Convert(value));
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogApiException(ex);
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("get")]
        public async Task<IActionResult> GetDriversAsync()
        {
            try
            {
                return Ok(await _driverModelRepository.GetDriversAsync());
            }
            catch (Exception ex)
            {
                _logger.LogApiException(ex);
                return StatusCode(500);
            }
        }
    }
}
