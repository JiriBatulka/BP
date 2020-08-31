using BP.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.EntityRepositories
{
    public interface IUserRepository
    {
        public Task<Guid> GetAssociatedUserIDAsync(Guid userIdentityID, RoleEnum role);
    }
}
