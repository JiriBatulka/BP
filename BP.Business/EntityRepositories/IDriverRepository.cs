using BP.Models;
using System.Threading.Tasks;

namespace BP.EntityRepositories
{
    public interface IDriverRepository
    {
        public Task AddDriverAsync(Driver driver);
    }
}
