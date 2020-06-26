using BP.Converters;
using BP.EntityRepositories;
using BP.Models;
using BP.StoredProcedures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderConverter orderConverter;
        private readonly OrderSP orderSP;
        public OrderRepository(OrderSP orderSP, OrderConverter orderConverter)
        {
            this.orderSP = orderSP;
            this.orderConverter = orderConverter;
        }

        public async Task<Guid> AddOrderAsync(Order order)
        {
            return await orderSP.AddOrderAsync(orderConverter.Convert(order));
        }
    }
}
