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
    public class VehicleSP
    {
        private readonly DataSettings dataSettings;
        public VehicleSP(DataSettings dataSettings)
        {
            this.dataSettings = dataSettings;
        }

        public async Task<Guid> AddVehicleAsync(Vehicle vehicle)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            conn.ConnectionString = dataSettings.ConnectionString;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = VehicleSPDefinitions.AddVehicle;

            cmd.Parameters.AddWithValue("@Type", vehicle.Type);
            cmd.Parameters.AddWithValue("@NumberPlate", vehicle.NumberPlate);
            cmd.Parameters.AddWithValue("@Colour", vehicle.Colour);
            cmd.Parameters.AddWithValue("@AdultSeats", vehicle.AdultSeats);
            cmd.Parameters.AddWithValue("@InfantSeats", vehicle.InfantSeats);
            cmd.Parameters.AddWithValue("@BootCapacity", vehicle.BootCapacity);
            cmd.Parameters.AddWithValue("@IsShared", vehicle.IsShared);

            cmd.Parameters.Add("@VehicleID", SqlDbType.UniqueIdentifier);
            cmd.Parameters["@VehicleID"].Direction = ParameterDirection.Output;

            try
            {
                conn.Open();
                await cmd.ExecuteNonQueryAsync();
                return (Guid)cmd.Parameters["@VehicleID"].Value;
            }
            finally
            {
                conn.Close();
            }
        }
        public async Task MoveVehicleAsync(Vehicle vehicle)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            conn.ConnectionString = dataSettings.ConnectionString;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = VehicleSPDefinitions.MoveVehicle;

            cmd.Parameters.AddWithValue("@VehicleID", vehicle.VehicleID);
            cmd.Parameters.AddWithValue("@CurrentLat", vehicle.CurrentLat);
            cmd.Parameters.AddWithValue("@CurrentLng", vehicle.CurrentLng);

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
