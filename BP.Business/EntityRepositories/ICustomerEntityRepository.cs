using BP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BP.EntityRepositories
{
    public interface ICustomerEntityRepository
    {
        public Task AddCustomerAsync(Customer customer);
        public Task MoveCustomerAsync(Customer customer);
        public Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}
