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
        private readonly OrderConverter orderConverter;

        public OrderController(IApiOrderRepository orderRepository, OrderConverter orderConverter)
        {
            this.orderRepository = orderRepository;
            this.orderConverter = orderConverter;
        }

        [HttpGet("add")]
        public async Task<Guid> AddOrderAsync([FromBody] OrderDTO.AddOrderDTO value)
        {
            return await orderRepository.AddOrderAsync(orderConverter.Convert(value));
        }
    }
}
