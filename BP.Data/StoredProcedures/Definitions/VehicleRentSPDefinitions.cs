using System.Collections.Generic;

namespace BP.StoredProcedures.Definitions
{
    internal class VehicleRentSPDefinitions
    {
        public static Dictionary<string, string> Definitions { get; } = new Dictionary<string, string>();
        public static string AddVehicleRent { get; } = "AddVehicleRent";

        public static void CreateDefinitions()
        {
            CreateAddVehicleRent();
        }

        private static void CreateAddVehicleRent()
        {
            Definitions[AddVehicleRent] =
                $@"CREATE OR ALTER PROCEDURE [dbo].[{AddVehicleRent}]
                        @TimeFrom datetime2(7),
                        @TimeUntil datetime2(7),
                        @IsOwned bit,
                        @VehicleID uniqueidentifier,
                        @DriverID uniqueidentifier
                    AS
                    BEGIN
                        SET NOCOUNT ON; 
                        INSERT INTO [dbo].[VehicleRents]  
                            (TimeFrom,  
                             TimeUntil,
                             IsOwned,
                             VehicleID,
                             DriverID)
                        VALUES (@TimeFrom,  
                             @TimeUntil,  
                             @IsOwned,
                             @VehicleID,
                             @DriverID);
                    END";
        }
    }
}
