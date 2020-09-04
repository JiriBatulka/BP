using BP.Entities;
using BP.StoredProcedures.Definitions;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
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
            //This is how stored procedure with output parameter is executed using EF:

            //SqlParameter CustomerID = new SqlParameter();
            //CustomerID.ParameterName = "@CustomerID";
            //CustomerID.SqlDbType = SqlDbType.UniqueIdentifier;
            //CustomerID.Direction = ParameterDirection.Output;
            //await BPContext.Database.ExecuteSqlInterpolatedAsync($"EXECUTE {CustomerSPDefinitions.AddCustomer} {customer.FirstName}, {customer.Surname}, {customer.PhoneNumber}, {customer.IsActive}, {CustomerID} OUT");

            //This is how SP with output parameter is executedusing ADO.NET:

            //SqlConnection conn = new SqlConnection();
            //SqlCommand cmd = new SqlCommand();
            //conn.ConnectionString = _dataSettings.ConnectionString;
            //cmd.Connection = conn;
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = CustomerSPDefinitions.AddCustomer;
            //cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            //cmd.Parameters.AddWithValue("@Surname", customer.Surname);
            //cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
            //cmd.Parameters.AddWithValue("@Email", customer.Email);
            //cmd.Parameters.AddWithValue("@UserIdentityID", customer.UserIdentityID);
            //conn.Open();
            //await cmd.ExecuteNonQueryAsync();

            //Using Dapper:

            using IDbConnection conn = new SqlConnection(_dataSettings.ConnectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@FirstName", customer.FirstName);
            parameters.Add("@Surname", customer.Surname);
            parameters.Add("@PhoneNumber", customer.PhoneNumber);
            parameters.Add("@Email", customer.Email);
            parameters.Add("@UserIdentityID", customer.UserIdentityID);

            await conn.ExecuteAsync(CustomerSPDefinitions.AddCustomer, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            using IDbConnection conn = new SqlConnection(_dataSettings.ConnectionString);
            return await conn.QueryAsync<Customer>(CustomerSPDefinitions.GetCustomers, commandType: CommandType.StoredProcedure);
        }

        public async Task MoveCustomerAsync(Customer customer)
        {
            using IDbConnection conn = new SqlConnection(_dataSettings.ConnectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@CustomerID", customer.CustomerID);
            parameters.Add("@CurrentLat", customer.CurrentLat);
            parameters.Add("@PhoneNCurrentLngumber", customer.CurrentLng);

            await conn.ExecuteAsync(CustomerSPDefinitions.MoveCustomer, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}