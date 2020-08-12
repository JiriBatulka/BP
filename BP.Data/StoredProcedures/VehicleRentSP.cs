using BP.Entities;
using BP.StoredProcedures.Definitions;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace BP.StoredProcedures
{
    public class VehicleRentSP
    {
        private readonly DataSettings _dataSettings;
        public VehicleRentSP(DataSettings dataSettings)
        {
            _dataSettings = dataSettings;
        }

        public async Task AddVehicleRentAsync(VehicleRent vehicleRent)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            conn.ConnectionString = _dataSettings.ConnectionString;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = VehicleRentSPDefinitions.AddVehicleRent;

            cmd.Parameters.AddWithValue("@IsOwned", vehicleRent.IsOwned);
            cmd.Parameters.AddWithValue("@TimeUntil", vehicleRent.TimeUntil);
            cmd.Parameters.AddWithValue("@TimeFrom", vehicleRent.TimeFrom);
            cmd.Parameters.AddWithValue("@DriverID", vehicleRent.DriverID);
            cmd.Parameters.AddWithValue("@VehicleID", vehicleRent.VehicleID);

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
