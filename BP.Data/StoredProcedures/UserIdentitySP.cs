using BP.Entities;
using BP.Exceptions;
using BP.StoredProcedures.Definitions;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace BP.StoredProcedures
{
    public class UserIdentitySP
    {
        private readonly DataSettings _dataSettings;
        public UserIdentitySP(DataSettings dataSettings)
        {
            _dataSettings = dataSettings;
        }

        public async Task<Guid> AddUserIdentityAsync(UserIdentity userIdentity)
        {
            //SqlConnection conn = new SqlConnection();
            //SqlCommand cmd = new SqlCommand();
            //conn.ConnectionString = _dataSettings.ConnectionString;
            //cmd.Connection = conn;
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = UserIdentitySPDefinitions.AddUserIdentity;

            //cmd.Parameters.AddWithValue("@Username", userIdentity.Username);
            //cmd.Parameters.AddWithValue("@PasswordHash", userIdentity.PasswordHash);
            //cmd.Parameters.AddWithValue("@PasswordSalt", userIdentity.PasswordSalt);
            //cmd.Parameters.AddWithValue("@Role", userIdentity.Role);

            //cmd.Parameters.Add("@UserIdentityID", SqlDbType.UniqueIdentifier);
            //cmd.Parameters["@UserIdentityID"].Direction = ParameterDirection.Output;

            //conn.Open();
            //await cmd.ExecuteNonQueryAsync();
            //return (Guid)cmd.Parameters["@UserIdentityID"].Value;


            using IDbConnection conn = new SqlConnection(_dataSettings.ConnectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@Username", userIdentity.Username);
            parameters.Add("@PasswordHash", userIdentity.PasswordHash);
            parameters.Add("@PasswordSalt", userIdentity.PasswordSalt);
            parameters.Add("@Role", userIdentity.Role);
            parameters.Add("@UserIdentityID", dbType: DbType.Guid, direction: ParameterDirection.Output);

            try
            {
                await conn.ExecuteAsync(UserIdentitySPDefinitions.AddUserIdentity, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601)
                {
                    throw new UniqueConstraintException($"Username already exists: {userIdentity.Username}");
                }
                else
                {
                    throw;
                }
            }
            return parameters.Get<Guid>("@UserIdentityID");
        }

        public async Task<UserIdentity> GetUserIdentity(string username)
        {
            using IDbConnection conn = new SqlConnection(_dataSettings.ConnectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@Username", username);
            return await conn.QueryFirstOrDefaultAsync<UserIdentity>(UserIdentitySPDefinitions.GetUserIdentityByUsername, parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}
