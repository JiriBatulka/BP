using BP.Models;
using System.Threading.Tasks;

namespace BP.EntityRepositories
{
    public interface IOrderEntityRepository
    {
        public Task AddOrderAsync(Order order);
    }
}
