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
                        @TimeFrom datetime2(7),
                        @TimeUntil datetime2(7),
                        @IsOwned bit,
                        @VehicleID uniqueidentifier,
                        @DriverID uniqueidentifier,
                        @VehicleRentID uniqueidentifier OUTPUT
                    AS
                    BEGIN
                        SET NOCOUNT ON; 
						DECLARE @returnVehicleRentID TABLE (id uniqueidentifier);
                        INSERT INTO [dbo].[VehicleRents]  
                            (TimeFrom,  
                             TimeUntil,
                             IsOwned,
                             VehicleID,
                             DriverID)
      				    OUTPUT inserted.VehicleRentID INTO @returnVehicleRentID
                        VALUES (@TimeFrom,  
                             @TimeUntil,  
                             @IsOwned,
                             @VehicleID,
                             @DriverID);
                        SELECT @VehicleRentID = r.id from @returnVehicleRentID r;
                    END";
        }
    }
}
