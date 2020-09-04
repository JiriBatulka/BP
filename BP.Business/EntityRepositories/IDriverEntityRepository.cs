using BP.Models;
using System.Threading.Tasks;

namespace BP.EntityRepositories
{
    public interface IDriverEntityRepository
    {
        public Task AddDriverAsync(Driver driver);
    }
}
