using BP.EntityRepositories;
using BP.Enums;
using BP.StoredProcedures;
using System;
using System.Threading.Tasks;

namespace BP.EntityRepositories
{
    public class UserEntityRepository : IUserEntityRepository
    {
        private readonly UserSP _userSP;

        public UserEntityRepository(UserSP userSP)
        {
            _userSP = userSP;
        }

        public async Task<Guid> GetAssociatedUserIDAsync(Guid userIdentityID, RoleEnum role)
            => role switch
            {
                RoleEnum.Customer => await _userSP.GetCustomerIDAsync(userIdentityID),
                RoleEnum.Driver => await _userSP.GetDriverIDAsync(userIdentityID),
                _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(role)),
            };
    }
}
