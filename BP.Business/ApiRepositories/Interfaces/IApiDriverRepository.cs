using BP.Models;
using System.Threading.Tasks;

namespace BP.ApiRepositories.Interfaces
{
    public interface IApiDriverRepository
    {
        public Task AddDriverAsync(Driver driver);
    }
}
