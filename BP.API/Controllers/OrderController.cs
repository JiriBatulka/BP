using System;
using System.Threading.Tasks;
using BP.Converters;
using BP.DTOs;
using BP.ModelRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BP.Controllers
{
    [Produces("application/json")]
    [Route("api/order")]
    [Authorize(Roles = "Customer,Driver")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderModelRepository _orderModelRepository;
        private readonly OrderDTOConverter _orderDTOConverter;
        private readonly CustomLogger _logger;

        public OrderController(OrderModelRepository orderModelRepository, OrderDTOConverter orderDTOConverter, CustomLogger logger)
        {
            _orderModelRepository = orderModelRepository;
            _orderDTOConverter = orderDTOConverter;
            _logger = logger;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddOrderAsync([FromBody] OrderDTO.AddOrderDTO value)
        {
            try
            {
                await _orderModelRepository.AddOrderAsync(_orderDTOConverter.Convert(value));
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
