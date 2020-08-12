using System.Threading.Tasks;
using BP.ApiRepositories.Interfaces;
using BP.Converters;
using BP.DTOs;
using BP.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BP.Controllers
{
    [Produces("application/json")]
    [Route("api/useridentity")]
    [ApiController]
    public class UserIdentityController : ControllerBase
    {
        private readonly IApiUserIdentityRepository _userIdentityRepository;
        private readonly UserIdentityDTOConverter _userIdentityDTOConverter;

        public UserIdentityController(IApiUserIdentityRepository userIdentityRepository, UserIdentityDTOConverter userIdentityDTOConverter)
        {
            _userIdentityRepository = userIdentityRepository;
            _userIdentityDTOConverter = userIdentityDTOConverter;
        }

        [HttpGet("gettoken")]
        public async Task<IActionResult> CheckUserIdentity([FromBody] UserIdentityDTO.CheckUserIdentityDTO value)
        {
            try
            {
                await _userIdentityRepository.CheckUserIdentityAsync(_userIdentityDTOConverter.Convert(value));
                return Ok();
            }
            catch (InvalidPasswordException)
            {
                return StatusCode(401);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
