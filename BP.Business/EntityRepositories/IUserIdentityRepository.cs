using BP.Models;
using System.Threading.Tasks;

namespace BP.EntityRepositories
{
    public interface IUserIdentityRepository
    {
        public Task<UserIdentity> AddUserIdentityAsync(UserIdentity userIdentity);
        public Task<(byte[] Hash, string Salt)> GetHashSaltAsync(string username);
    }
}
