using System.Threading.Tasks;
using BP.ApiRepositories.Interfaces;
using BP.Converters;
using BP.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BP.Controllers
{
    [Produces("application/json")]
    [Route("api/driver")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IApiDriverRepository _driverRepository;
        private readonly DriverDTOConverter _driverDTOConverter;

        public DriverController(IApiDriverRepository driverRepository, DriverDTOConverter driverDTOConverter)
        {
            _driverRepository = driverRepository;
            _driverDTOConverter = driverDTOConverter;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddDriverAsync([FromBody] DriverDTO.AddDriverDTO value)
        {
            try
            {
                await _driverRepository.AddDriverAsync(_driverDTOConverter.Convert(value));
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
