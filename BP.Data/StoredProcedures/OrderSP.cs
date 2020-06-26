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
    public class OrderSP
    {
        private readonly DataSettings dataSettings;
        public OrderSP(DataSettings dataSettings)
        {
            this.dataSettings = dataSettings;
        }

        public async Task<Guid> AddOrderAsync(Order order)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            conn.ConnectionString = dataSettings.ConnectionString;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = OrderSPDefinitions.AddOrder;

            cmd.Parameters.AddWithValue("@StartTime", order.StartTime);
            cmd.Parameters.AddWithValue("@VehicleArriveEstimate", order.VehicleArriveEstimate);
            cmd.Parameters.AddWithValue("@EndTimeEstimate", order.EndTimeEstimate);
            cmd.Parameters.AddWithValue("@StartLocationLat", order.StartLocationLat);
            cmd.Parameters.AddWithValue("@StartLocationLng", order.StartLocationLng);
            cmd.Parameters.AddWithValue("@EndLocationLat", order.EndLocationLat);
            cmd.Parameters.AddWithValue("@EndLocationLng", order.EndLocationLng);
            cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);
            cmd.Parameters.AddWithValue("@VehicleID", order.VehicleID);

            cmd.Parameters.Add("@OrderID", SqlDbType.UniqueIdentifier);
            cmd.Parameters["@OrderID"].Direction = ParameterDirection.Output;

            try
            {
                conn.Open();
                await cmd.ExecuteNonQueryAsync();
                return (Guid)cmd.Parameters["@OrderID"].Value;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
