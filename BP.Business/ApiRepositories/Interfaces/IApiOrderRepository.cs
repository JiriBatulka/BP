using BP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.ApiRepositories.Interfaces
{
    public interface IApiOrderRepository
    {
        public Task<Guid> AddOrderAsync(Order order);
    }
}
