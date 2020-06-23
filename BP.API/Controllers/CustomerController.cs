using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IApiCustomerRepository customerRepository;
        private readonly CustomerDTOConverter customerDTOConverter;

        public CustomerController(IApiCustomerRepository customerRepository, CustomerDTOConverter customerDTOConverter)
        {
            this.customerRepository = customerRepository;
            this.customerDTOConverter = customerDTOConverter;
        }

        [HttpGet("add")]
        public async Task<IActionResult> AddCustomerAsync([FromBody]CustomerDTO.AddCustomerDTO value)
        {
            try
            {
                return Ok(await customerRepository.AddCustomerAsync(customerDTOConverter.Convert(value)));
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("move")]
        public async Task<IActionResult> MoveCustomerAsync([FromBody] CustomerDTO.MoveCustomerDTO value)
        {
            try
            {
                return Ok(await customerRepository.MoveCustomerAsync(customerDTOConverter.Convert(value)));
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
