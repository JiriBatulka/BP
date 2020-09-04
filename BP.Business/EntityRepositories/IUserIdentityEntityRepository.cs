using BP.Models;
using System.Threading.Tasks;

namespace BP.EntityRepositories
{
    public interface IUserIdentityEntityRepository
    {
        public Task<UserIdentity> AddUserIdentityAsync(UserIdentity userIdentity);
        public Task<UserIdentity> GetUserIdentityAsync(string username);
    }
}
