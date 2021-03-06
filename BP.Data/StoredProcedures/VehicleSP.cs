﻿using BP.Entities;
using BP.StoredProcedures.Definitions;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace BP.StoredProcedures
{
    public class VehicleSP
    {
        private readonly DataSettings _dataSettings;
        public VehicleSP(DataSettings dataSettings)
        {
            _dataSettings = dataSettings;
        }

        public async Task AddVehicleAsync(Vehicle vehicle)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            conn.ConnectionString = _dataSettings.ConnectionString;
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
        public async Task MoveVehicleAsync(Vehicle vehicle)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            conn.ConnectionString = _dataSettings.ConnectionString;
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
