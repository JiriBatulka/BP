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
    public class VehicleRentSP
    {
        private readonly DataSettings dataSettings;
        public VehicleRentSP(DataSettings dataSettings)
        {
            this.dataSettings = dataSettings;
        }

        public async Task<Guid> AddVehicleRentAsync(VehicleRent vehicleRent)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            conn.ConnectionString = dataSettings.ConnectionString;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = VehicleRentSPDefinitions.AddVehicleRent;

            cmd.Parameters.AddWithValue("@IsOwned", vehicleRent.IsOwned);
            cmd.Parameters.AddWithValue("@TimeUntil", vehicleRent.TimeUntil);
            cmd.Parameters.AddWithValue("@TimeFrom", vehicleRent.TimeFrom);
            cmd.Parameters.AddWithValue("@DriverID", vehicleRent.DriverID);
            cmd.Parameters.AddWithValue("@VehicleID", vehicleRent.VehicleID);

            cmd.Parameters.Add("@VehicleRentID", SqlDbType.UniqueIdentifier);
            cmd.Parameters["@VehicleRentID"].Direction = ParameterDirection.Output;

            try
            {
                conn.Open();
                await cmd.ExecuteNonQueryAsync();
                return (Guid)cmd.Parameters["@VehicleRentID"].Value;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
