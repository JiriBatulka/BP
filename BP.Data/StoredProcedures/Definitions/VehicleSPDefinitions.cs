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

        private static void CreateMoveVehicle()
        {
            Definitions[MoveVehicle] =
                @"CREATE PROCEDURE [dbo].[AddVehicle]
                        @VehicleID uniqueidentifier,
                        @Type nvarchar(63),
                        @NumberPlate nvarchar(31),
                        @Colour nvarchar(15),
                        @AdultSeats int,
                        @InfantSeats int,
                        @BootCapacity int,
                        @IsShared bit,
                    AS
                    BEGIN
                        INSERT INTO [dbo].[Vehicles] (
                             VehicleID,  
                             Type,  
                             NumberPlate,  
                             Colour,
                             AdultSeats,  
                             InfantSeats,  
                             BootCapacity,  
                             IsShared)
  
                        VALUES ( 
                             @VehicleID,  
                             @Type,  
                             @NumberPlate,  
                             @Colour,
                             @AdultSeats,  
                             @InfantSeats,  
                             @BootCapacity,  
                             @IsShared) 
                    END";
        }

        private static void CreateAddVehicle()
        {
            Definitions[MoveVehicle] =
                @"CREATE PROCEDURE [dbo].[MoveVehicle]
                        @VehicleID uniqueidentifier,
                        @CurrentLat nvarchar(31),
                        @CurrentLng nvarchar(31)
                    AS
                    BEGIN
                        UPDATE [dbo].[Vehicles]
                        SET CurrentLat = @CurrentLat, CurrentLng = @CurrentLng
                        WHERE VehicleID = @VehicleID
                    END";
        }
    }
}
