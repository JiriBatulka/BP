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

