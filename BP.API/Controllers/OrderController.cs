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
        private readonly IApiOrderRepository _orderRepository;
        private readonly OrderDTOConverter _orderDTOConverter;

        public OrderController(IApiOrderRepository orderRepository, OrderDTOConverter orderDTOConverter)
        {
            _orderRepository = orderRepository;
            _orderDTOConverter = orderDTOConverter;
        }

        [HttpGet("add")]
        public async Task<IActionResult> AddOrderAsync([FromBody] OrderDTO.AddOrderDTO value)
        {
            try
            {
                await _orderRepository.AddOrderAsync(_orderDTOConverter.Convert(value));
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
