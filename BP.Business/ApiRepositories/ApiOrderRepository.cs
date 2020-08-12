using BP.ApiRepositories.Interfaces;
using BP.EntityRepositories;
using BP.Models;
using System.Threading.Tasks;

namespace BP.ApiRepositories
{
    public class ApiOrderRepository : IApiOrderRepository
    {
        private readonly IOrderRepository _orderRepository;

        public ApiOrderRepository(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task AddOrderAsync(Order order)
        {
            await _orderRepository.AddOrderAsync(order);
        }
    }
}
