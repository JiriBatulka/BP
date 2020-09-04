using BP.Entities;
using BP.StoredProcedures.Definitions;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace BP.StoredProcedures
{
    public class DriverSP
    {
        private readonly DataSettings _dataSettings;
        public DriverSP(DataSettings dataSettings)
        {
            _dataSettings = dataSettings;
        }

        public async Task AddDriverAsync(Driver driver)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            conn.ConnectionString = _dataSettings.ConnectionString;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = DriverSPDefinitions.AddDriver;

            cmd.Parameters.AddWithValue("@FirstName", driver.FirstName);
            cmd.Parameters.AddWithValue("@Surname", driver.Surname);
            cmd.Parameters.AddWithValue("@PhoneNumber", driver.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", driver.Email);
            cmd.Parameters.AddWithValue("@UserIdentityID", driver.UserIdentityID);

            try
            {
                conn.Open();
                await cmd.ExecuteNonQueryAsync();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

