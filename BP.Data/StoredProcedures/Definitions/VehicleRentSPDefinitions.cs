using System;
using System.Collections.Generic;
using System.Text;

namespace BP.StoredProcedures.Definitions
{
    internal class VehicleRentSPDefinitions
    {
        public static Dictionary<string, string> Definitions = new Dictionary<string, string>();
        public static string AddVehicleRent = "AddVehicleRent";

        static VehicleRentSPDefinitions()
        {
            CreateAddVehicleRent();
        }

        private static void CreateAddVehicleRent()
        {
            Definitions[AddVehicleRent] =
                @"CREATE PROCEDURE [dbo].[AddVehicleRent]
                        @VehicleRentID uniqueidentifier,
                        @TimeFrom datetime2(7),
                        @TimeUntil datetime2(7),
                        @IsOwned bit,
                        @VehicleID uniqueidentifier,
                        @DriverID uniqueidentifier
                    AS
                    BEGIN
                        INSERT INTO [dbo].[VehicleRents]  
                            (VehicleRentID,  
                             TimeFrom,  
                             TimeUntil,
                             IsOwned,
                             VehicleID,
                             DriverID)
  
                        VALUES ( 
                             @VehicleRentID,  
                             @TimeFrom,  
                             @TimeUntil,  
                             @IsOwned,
                             @VehicleID,
                             @DriverID)  
                    END";
        }
    }
}
