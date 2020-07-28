using BP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.ApiRepositories.Interfaces
{
    public interface IApiCustomerRepository
    {
        public Task AddCustomerAsync(Customer customer);
        public Task MoveCustomerAsync(Customer customer);
    }
}
