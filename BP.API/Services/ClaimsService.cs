using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BP.Services
{
    public class ClaimsService
    {
        internal Guid GetName(IEnumerable<Claim> claims)
        {
            return Guid.Parse(claims.First(x => x.Type.EndsWith("/name")).Value);
        }
    }
}
