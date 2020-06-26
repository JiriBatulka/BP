using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BP.ApiRepositories.Interfaces;
using BP.Converters;
using BP.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BP.Controllers
{
    [Produces("application/json")]
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IApiOrderRepository orderRepository;
        private readonly OrderDTOConverter orderDTOConverter;

        public OrderController(IApiOrderRepository orderRepository, OrderDTOConverter orderDTOConverter)
        {
            this.orderRepository = orderRepository;
            this.orderDTOConverter = orderDTOConverter;
        }

        [HttpGet("add")]
        public async Task<IActionResult> AddOrderAsync([FromBody] OrderDTO.AddOrderDTO value)
        {
            try
            {
                return Ok(await orderRepository.AddOrderAsync(orderDTOConverter.Convert(value)));
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
