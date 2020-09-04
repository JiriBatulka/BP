using BP.EntityRepositories;
using BP.Models;
using System.Threading.Tasks;

namespace BP.ModelRepositories
{
    public class OrderModelRepository
    {
        private readonly EntityRepositories.IOrderEntityRepository _orderRepository;

        public OrderModelRepository(EntityRepositories.IOrderEntityRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task AddOrderAsync(Order order)
        {
            await _orderRepository.AddOrderAsync(order);
        }
    }
}
