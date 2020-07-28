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
        private readonly DataSettings _dataSettings;
        public OrderSP(DataSettings dataSettings)
        {
            _dataSettings = dataSettings;
        }

        public async Task AddOrderAsync(Order order)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            conn.ConnectionString = _dataSettings.ConnectionString;
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
