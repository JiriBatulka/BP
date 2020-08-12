using BP.Models;
using System.Threading.Tasks;

namespace BP.ApiRepositories.Interfaces
{
    public interface IApiUserIdentityRepository
    {
        public Task CheckUserIdentityAsync(UserIdentity userIdentity);
    }
}