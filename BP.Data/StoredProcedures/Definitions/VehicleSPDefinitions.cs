using System;
using System.Collections.Generic;
using System.Text;

namespace BP.StoredProcedures.Definitions
{
    internal class VehicleSPDefinitions
    {
        public static Dictionary<string, string> Definitions = new Dictionary<string, string>();
        public static string AddVehicle = "AddVehicle";
        public static string MoveVehicle = "MoveVehicle";

        static VehicleSPDefinitions()
        {
            CreateAddVehicle();
            CreateMoveVehicle();
        }

        private static void CreateAddVehicle()
        {
            Definitions[AddVehicle] =
                @"CREATE PROCEDURE [dbo].[AddVehicle]
                        @Type nvarchar(63),
                        @NumberPlate nvarchar(31),
                        @Colour nvarchar(15),
                        @AdultSeats int,
                        @InfantSeats int,
                        @BootCapacity int,
                        @IsShared bit,
                        @VehicleID uniqueidentifier OUTPUT
                    AS
                    BEGIN
                        SET NOCOUNT ON; 
						DECLARE @returnVehicleID TABLE (id uniqueidentifier);
                        INSERT INTO [dbo].[Vehicles] 
                            (Type,  
                             NumberPlate,  
                             Colour,
                             AdultSeats,  
                             InfantSeats,  
                             BootCapacity,  
                             IsShared)
        				OUTPUT inserted.VehicleID INTO @returnVehicleID
                        VALUES (@Type,  
                             @NumberPlate,  
                             @Colour,
                             @AdultSeats,  
                             @InfantSeats,  
                             @BootCapacity,  
                             @IsShared);
                        SELECT @VehicleID = r.id from @returnVehicleID r;
                    END";
        }

        private static void CreateMoveVehicle()
        {
            Definitions[MoveVehicle] =
                @"CREATE PROCEDURE [dbo].[MoveVehicle]
                        @VehicleID uniqueidentifier,
                        @CurrentLat float,
                        @CurrentLng float
                    AS
                    BEGIN
                        UPDATE [dbo].[Vehicles]
                        SET CurrentLat = @CurrentLat, CurrentLng = @CurrentLng
                        WHERE VehicleID = @VehicleID
                    END";
        }
    }
}
