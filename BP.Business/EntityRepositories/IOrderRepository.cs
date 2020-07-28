using BP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.EntityRepositories
{
    public interface IOrderRepository
    {
        public Task AddOrderAsync(Order order);
    }
}
