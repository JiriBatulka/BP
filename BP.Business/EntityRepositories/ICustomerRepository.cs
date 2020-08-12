using BP.Models;
using System.Threading.Tasks;

namespace BP.EntityRepositories
{
    public interface ICustomerRepository
    {
        public Task AddCustomerAsync(Customer customer);
        public Task MoveCustomerAsync(Customer customer);
    }
}
