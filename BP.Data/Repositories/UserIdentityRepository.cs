using BP.Converters;
using BP.EntityRepositories;
using BP.Models;
using BP.StoredProcedures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.Repositories
{
    public class UserIdentityRepository : IUserIdentityRepository
    {
        private readonly UserIdentityConverter _userIdentityConverter;
        private readonly UserIdentitySP _userIdentitySP;
        public UserIdentityRepository(UserIdentitySP userIdentitySP, UserIdentityConverter userIdentityConverter)
        {
            _userIdentitySP = userIdentitySP;
            _userIdentityConverter = userIdentityConverter;
        }

        public async Task<Guid> AddUserIdentityAsync(UserIdentity userIdentity)
        {
            return await _userIdentitySP.AddUserIdentityAsync(_userIdentityConverter.Convert(userIdentity));
        }
    }
}
