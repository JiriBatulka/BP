using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BP.ApiRepositories.Interfaces;
using BP.Converters;
using BP.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BP.Controllers
{
    [Produces("application/json")]
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IApiCustomerRepository _customerRepository;
        private readonly CustomerDTOConverter _customerDTOConverter;
        private readonly CustomLogger _logger;

        public CustomerController(IApiCustomerRepository customerRepository, CustomerDTOConverter customerDTOConverter, CustomLogger logger)
        {
            _customerRepository = customerRepository;
            _customerDTOConverter = customerDTOConverter;
            _logger = logger;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCustomerAsync([FromBody]CustomerDTO.AddCustomerDTO value)
        {
            try
            {
                //for testing purposes only!!!
                using var rsa = new RSACryptoServiceProvider(1024);
                try
                {
                    byte[] dataToEncrypt = Encoding.UTF8.GetBytes(value.EncryptedPassword);
                    rsa.FromXmlString("<RSAKeyValue><Modulus>v8bjybJHOTrgRh6y1FVZEPhVJlfPhEO7Iz2aEWMQo3oNqVPpvLwIa5RclB8+mmI0my5aW0ujRdqh9CgMCuI6hZE2kakieqT2eSfDqIXRlC1/AGoqLYBeaXrTSsxdHzGjNVeWheFPJQzEMPl3q8GeHTyjqtr87sUbSOzLFr/sl9E =</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");
                    byte[] encryptedData = rsa.Encrypt(dataToEncrypt, true);
                    value.EncryptedPassword = Convert.ToBase64String(encryptedData);
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }

                await _customerRepository.AddCustomerAsync(_customerDTOConverter.Convert(value));
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogApiException(ex);
                return StatusCode(500);
            }
        }

        [HttpGet("move")]
        public async Task<IActionResult> MoveCustomerAsync([FromBody] CustomerDTO.MoveCustomerDTO value)
        {
            try
            {
                await _customerRepository.MoveCustomerAsync(_customerDTOConverter.Convert(value));
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
