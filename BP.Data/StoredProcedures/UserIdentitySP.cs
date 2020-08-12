using BP.Entities;
using BP.StoredProcedures.Definitions;
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
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            conn.ConnectionString = _dataSettings.ConnectionString;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = UserIdentitySPDefinitions.AddUserIdentity;

            cmd.Parameters.AddWithValue("@Username", userIdentity.Username);
            cmd.Parameters.AddWithValue("@PasswordHash", userIdentity.PasswordHash);
            cmd.Parameters.AddWithValue("@PasswordSalt", userIdentity.PasswordSalt);
            cmd.Parameters.AddWithValue("@Role", userIdentity.Role);

            cmd.Parameters.Add("@UserIdentityID", SqlDbType.UniqueIdentifier);
            cmd.Parameters["@UserIdentityID"].Direction = ParameterDirection.Output;

            try
            {
                conn.Open();
                await cmd.ExecuteNonQueryAsync();
                return (Guid)cmd.Parameters["@UserIdentityID"].Value;
            }
            finally
            {
                conn.Close();
            }
        }

        public async Task<(byte[] Hash, string Salt)> GetHashSaltAsync(string username)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            conn.ConnectionString = _dataSettings.ConnectionString;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = UserIdentitySPDefinitions.GetHashSalt;

            cmd.Parameters.AddWithValue("@Username", username);

            cmd.Parameters.Add("@PasswordHash", SqlDbType.UniqueIdentifier);
            cmd.Parameters["@PasswordHash"].Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PasswordSalt", SqlDbType.UniqueIdentifier);
            cmd.Parameters["@PasswordSalt"].Direction = ParameterDirection.Output;

            try
            {
                conn.Open();
                await cmd.ExecuteNonQueryAsync();
                return ((byte[])cmd.Parameters["@PasswordHash"].Value, (string)cmd.Parameters["@PasswordSalt"].Value);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
