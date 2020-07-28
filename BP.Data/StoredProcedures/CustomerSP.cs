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
    public class CustomerSP
    {
        private readonly DataSettings _dataSettings;
        public CustomerSP(DataSettings dataSettings)
        {
            _dataSettings = dataSettings;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            //This is how stored procedure with output parameter is executed:
            //var CustomerID = new SqlParameter();
            //CustomerID.ParameterName = "@CustomerID";
            //CustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            //CustomerID.Direction = ParameterDirection.Output;
            //await BPContext.Database.ExecuteSqlInterpolatedAsync($"EXECUTE {CustomerSPDefinitions.AddCustomer} {customer.FirstName}, {customer.Surname}, {customer.PhoneNumber}, {customer.IsActive}, {CustomerID} OUT");

            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            conn.ConnectionString = _dataSettings.ConnectionString;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = CustomerSPDefinitions.AddCustomer;

            cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@Surname", customer.Surname);
            cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);

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

        public async Task MoveCustomerAsync(Customer customer)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            conn.ConnectionString = _dataSettings.ConnectionString;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = CustomerSPDefinitions.MoveCustomer;

            cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
            cmd.Parameters.AddWithValue("@CurrentLat", customer.CurrentLat);
            cmd.Parameters.AddWithValue("@CurrentLng", customer.CurrentLng);

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