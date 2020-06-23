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
        public async Task<Guid> AddOrderAsync([FromBody] OrderDTO.AddOrderDTO value)
        {
            return await orderRepository.AddOrderAsync(orderDTOConverter.Convert(value));
        }
    }
}
