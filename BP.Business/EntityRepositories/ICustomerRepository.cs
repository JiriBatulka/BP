using BP.Models;
using System;
using System.Threading.Tasks;

namespace BP.EntityRepositories
{
    public interface ICustomerRepository
    {
        public Task<Guid> AddCustomerAsync(Customer customer);
        public Task MoveCustomerAsync(Customer customer);
    }
}
