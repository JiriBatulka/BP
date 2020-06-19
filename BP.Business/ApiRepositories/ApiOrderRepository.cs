using BP.ApiRepositories.Interfaces;
using BP.EntityRepositories;
using BP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.ApiRepositories
{
    public class ApiOrderRepository : IApiOrderRepository
    {
        private IOrderRepository orderRepository;

        public ApiOrderRepository(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public Task<Guid> AddOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
