using BP.Models;
using System.Threading.Tasks;

namespace BP.ApiRepositories.Interfaces
{
    public interface IApiOrderRepository
    {
        public Task AddOrderAsync(Order order);
    }
}
