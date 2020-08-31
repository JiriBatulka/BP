using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BP.ApiRepositories.Interfaces;
using BP.Converters;
using BP.DTOs;
using BP.Enums;
using BP.Exceptions;
using BP.Models;
using BP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BP.Controllers
{
    [Produces("application/json")]
    [Route("api/customer")]
    [Authorize(Roles = "Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IApiCustomerRepository _customerRepository;
        private readonly CustomerDTOConverter _customerDTOConverter;
        private readonly CustomLogger _logger;
        private readonly ClaimsService _claimsService;

        public CustomerController(IApiCustomerRepository customerRepository, CustomerDTOConverter customerDTOConverter, CustomLogger logger, ClaimsService claimsService)
        {
            _customerRepository = customerRepository;
            _customerDTOConverter = customerDTOConverter;
            _logger = logger;
            _claimsService = claimsService;
        }

        [AllowAnonymous]
        [HttpGet("add")]
        public async Task<IActionResult> AddCustomerAsync([FromBody]CustomerDTO.AddCustomerDTO value)
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

                await _customerRepository.AddCustomerAsync(_customerDTOConverter.Convert(value));
                return StatusCode(201);
            }
            catch (UniqueConstraintException ex)
            {
                return StatusCode(409, ex.Message);
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

        [HttpPost("move")]
        public async Task<IActionResult> MoveCustomerAsync([FromBody] CustomerDTO.MoveCustomerDTO value)
        {
            try
            {
                Customer customer = _customerDTOConverter.Convert(value);
                customer.UserID = _claimsService.GetName(User.Claims);
                await _customerRepository.MoveCustomerAsync(customer);
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
        public async Task<IActionResult> GetCustomersAsync()
        {
            try
            {
                return Ok(await _customerRepository.GetCustomers();
            }
            catch (Exception ex)
            {
                _logger.LogApiException(ex);
                return StatusCode(500);
            }
        }
    }
}
