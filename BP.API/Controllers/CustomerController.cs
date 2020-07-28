using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BP.ApiRepositories.Interfaces;
using BP.Converters;
using BP.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        [HttpGet("add")]
        public async Task<IActionResult> AddCustomerAsync([FromBody]CustomerDTO.AddCustomerDTO value)
        {
            try
            {
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
