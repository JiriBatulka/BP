using BP.Entities;
using BP.StoredProcedures.Definitions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace BP.StoredProcedures
{
    public class DriverSP
    {
        private readonly DataSettings dataSettings;
        public DriverSP(DataSettings dataSettings)
        {
            this.dataSettings = dataSettings;
        }

        public async Task<Guid> AddDriverAsync(Driver driver)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            conn.ConnectionString = dataSettings.ConnectionString;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = DriverSPDefinitions.AddDriver;

            cmd.Parameters.AddWithValue("@FirstName", driver.FirstName);
            cmd.Parameters.AddWithValue("@Surname", driver.Surname);
            cmd.Parameters.AddWithValue("@PhoneNumber", driver.PhoneNumber);

            cmd.Parameters.Add("@DriverID", SqlDbType.UniqueIdentifier);
            cmd.Parameters["@DriverID"].Direction = ParameterDirection.Output;

            try
            {
                conn.Open();
                await cmd.ExecuteNonQueryAsync();
                return (Guid)cmd.Parameters["@DriverID"].Value;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

