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
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IApiCustomerRepository customerRepository;
        private readonly CustomerConverter customerConverter;

        public CustomerController(IApiCustomerRepository customerRepository, CustomerConverter customerConverter)
        {
            this.customerRepository = customerRepository;
            this.customerConverter = customerConverter;
        }

        [HttpGet("add")]
        public async Task<Guid> AddCustomerAsync([FromBody] CustomerDTO.AddCustomerDTO value)
        {
            return await customerRepository.AddCustomerAsync(customerConverter.Convert(value));
        }

        [HttpGet("move")]
        public async Task MoveCustomerAsync([FromBody] CustomerDTO.MoveCustomerDTO value)
        {
            await customerRepository.MoveCustomerAsync(customerConverter.Convert(value));
        }
    }
}
