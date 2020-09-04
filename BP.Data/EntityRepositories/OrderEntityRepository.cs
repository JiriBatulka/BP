using BP.Converters;
using BP.EntityRepositories;
using BP.Models;
using BP.StoredProcedures;
using System.Threading.Tasks;

namespace BP.EntityRepositories
{
    public class OrderEntityRepository : IOrderEntityRepository
    {
        private readonly OrderConverter _orderConverter;
        private readonly OrderSP _orderSP;
        public OrderEntityRepository(OrderSP orderSP, OrderConverter orderConverter)
        {
            _orderSP = orderSP;
            _orderConverter = orderConverter;
        }

        public async Task AddOrderAsync(Order order)
        {
            await _orderSP.AddOrderAsync(_orderConverter.Convert(order));
        }
    }
}
