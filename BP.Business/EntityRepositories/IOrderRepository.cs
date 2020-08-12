using BP.Models;
using System.Threading.Tasks;

namespace BP.EntityRepositories
{
    public interface IOrderRepository
    {
        public Task AddOrderAsync(Order order);
    }
}
