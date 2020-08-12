using System.Collections.Generic;

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
                @"CREATE OR ALTER PROCEDURE [dbo].[AddVehicle]
                        @Type nvarchar(255),
                        @NumberPlate nvarchar(255),
                        @Colour nvarchar(255),
                        @AdultSeats int,
                        @InfantSeats int,
                        @BootCapacity int,
                        @IsShared bit
                    AS
                    BEGIN
                        SET NOCOUNT ON; 
                        INSERT INTO [dbo].[Vehicles] 
                            (Type,  
                             NumberPlate,  
                             Colour,
                             AdultSeats,  
                             InfantSeats,  
                             BootCapacity,  
                             IsShared)
                        VALUES (@Type,  
                             @NumberPlate,  
                             @Colour,
                             @AdultSeats,  
                             @InfantSeats,  
                             @BootCapacity,  
                             @IsShared);
                    END";
        }

        private static void CreateMoveVehicle()
        {
            Definitions[MoveVehicle] =
                @"CREATE OR ALTER PROCEDURE [dbo].[MoveVehicle]
                        @VehicleID uniqueidentifier,
                        @CurrentLat float,
                        @CurrentLng float
                    AS
                    BEGIN
                        SET NOCOUNT ON; 
                        UPDATE [dbo].[Vehicles]
                        SET CurrentLat = @CurrentLat, CurrentLng = @CurrentLng
                        WHERE VehicleID = @VehicleID
                    END";
        }
    }
}
