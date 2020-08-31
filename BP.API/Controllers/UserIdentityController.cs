using System;
using System.Security.Cryptography;
using System.Text;
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
        private readonly CustomLogger _logger;

        public UserIdentityController(IApiUserIdentityRepository userIdentityRepository, UserIdentityDTOConverter userIdentityDTOConverter, CustomLogger logger)
        {
            _userIdentityRepository = userIdentityRepository;
            _userIdentityDTOConverter = userIdentityDTOConverter;
            _logger = logger;
        }

        [HttpGet("gettoken")]
        public async Task<IActionResult> GetAuthTokenAsync([FromBody] UserIdentityDTO.GetAuthTokenDTO value)
        {
            try
            {
                ////for testing purposes only!!!
                //using var rsa = new RSACryptoServiceProvider(1024);
                //try
                //{
                //    byte[] dataToEncrypt = Encoding.UTF8.GetBytes(value.EncryptedPassword);
                //    rsa.FromXmlString("<RSAKeyValue><Modulus>v8bjybJHOTrgRh6y1FVZEPhVJlfPhEO7Iz2aEWMQo3oNqVPpvLwIa5RclB8+mmI0my5aW0ujRdqh9CgMCuI6hZE2kakieqT2eSfDqIXRlC1/AGoqLYBeaXrTSsxdHzGjNVeWheFPJQzEMPl3q8GeHTyjqtr87sUbSOzLFr/sl9E =</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");
                //    byte[] encryptedData = rsa.Encrypt(dataToEncrypt, true);
                //    value.EncryptedPassword = Convert.ToBase64String(encryptedData);
                //}
                //finally
                //{
                //    rsa.PersistKeyInCsp = false;
                //}

                return Ok(await _userIdentityRepository.GetAuthTokenAsync(_userIdentityDTOConverter.Convert(value)));
            }
            catch (InvalidPasswordException)
            {
                return StatusCode(401);
            }
            catch (InvalidApiPasswordException)
            {
                return StatusCode(401);
            }
            catch (Exception ex)
            {
                _logger.LogApiException(ex);
                return StatusCode(500);
            }
        }
    }
}
