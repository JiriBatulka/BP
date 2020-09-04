using BP.Enums;
using System;
using System.Threading.Tasks;

namespace BP.EntityRepositories
{
    public interface IUserEntityRepository
    {
        public Task<Guid> GetAssociatedUserIDAsync(Guid userIdentityID, RoleEnum role);
    }
}
