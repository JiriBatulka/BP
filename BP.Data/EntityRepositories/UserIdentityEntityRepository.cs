using BP.Converters;
using BP.EntityRepositories;
using BP.Models;
using BP.StoredProcedures;
using System.Threading.Tasks;

namespace BP.EntityRepositories
{
    public class UserIdentityEntityRepository : IUserIdentityEntityRepository
    {
        private readonly UserIdentityConverter _userIdentityConverter;
        private readonly UserIdentitySP _userIdentitySP;
        public UserIdentityEntityRepository(UserIdentitySP userIdentitySP, UserIdentityConverter userIdentityConverter)
        {
            _userIdentitySP = userIdentitySP;
            _userIdentityConverter = userIdentityConverter;
        }

        public async Task<UserIdentity> AddUserIdentityAsync(UserIdentity userIdentity)
        {
            userIdentity.UserIdentityID = await _userIdentitySP.AddUserIdentityAsync(_userIdentityConverter.Convert(userIdentity));
            return userIdentity;
        }

        public async Task<UserIdentity> GetUserIdentityAsync(string username)
        {
            return _userIdentityConverter.Convert(await _userIdentitySP.GetUserIdentity(username));
        }
    }
}
