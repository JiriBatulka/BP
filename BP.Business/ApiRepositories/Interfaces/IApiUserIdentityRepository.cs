using BP.Models;
using System.Threading.Tasks;

namespace BP.ApiRepositories.Interfaces
{
    public interface IApiUserIdentityRepository
    {
        public Task<string> GetAuthTokenAsync(UserIdentity userIdentity);
    }
}