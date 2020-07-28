﻿using System;
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
