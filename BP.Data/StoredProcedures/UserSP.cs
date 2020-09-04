using BP.StoredProcedures.Definitions;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace BP.StoredProcedures
{
    public class UserSP
    {
        private readonly DataSettings _dataSettings;
        public UserSP(DataSettings dataSettings)
        {
            _dataSettings = dataSettings;
        }

        internal async Task<Guid> GetCustomerIDAsync(Guid userIdentityID)
        {
            using IDbConnection conn = new SqlConnection(_dataSettings.ConnectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@UserIdentityID", userIdentityID);
            return await conn.QueryFirstOrDefaultAsync<Guid>(CustomerSPDefinitions.GetCustomerIDByUserIdentityID, parameters,
                commandType: CommandType.StoredProcedure);
        }
        internal Task<Guid> GetDriverIDAsync(Guid userIdentityID)
        {
            throw new NotImplementedException();
        }
    }
}
