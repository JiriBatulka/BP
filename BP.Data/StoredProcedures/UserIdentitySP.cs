using BP.Entities;
using BP.StoredProcedures.Definitions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
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
            cmd.Parameters.AddWithValue("@Password", userIdentity.Password);
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
    }
}
