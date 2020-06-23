using System;
using System.Collections.Generic;
using System.Text;

namespace BP.StoredProcedures.Definitions
{
    internal class OrderSPDefinitions
    {
        public static Dictionary<string, string> Definitions = new Dictionary<string, string>();
        public static string AddOrder = "AddOrder";

        static OrderSPDefinitions()
        {
            CreateAddOrder();
        }

        private static void CreateAddOrder()
        {
            Definitions[AddOrder] =
                @"CREATE PROCEDURE [dbo].[AddOrder]
                        @OrderID uniqueidentifier,
                        @StartTime datetime2(7),
                        @VehicleArriveEstimate datetime2(7),
                        @EndTimeEstimate datetime2(7),
                        @StartLocationLat float,
                        @StartLocationLng float,
                        @EndLocationLat float,
                        @EndLocationLng float,
                        @CustomerID uniqueidentifier,
                        @VehicleID uniqueidentifier,
                        @IsActive bit)
                    AS
                    BEGIN
                        INSERT INTO [dbo].[Orders]  
                            (OrderID,  
                             StartTime,  
                             VehicleArriveEstimate,
                             EndTimeEstimate,
                             StartLocationLat,
                             StartLocationLng,
                             EndLocationLat,
                             EndLocationLng,
                             CustomerID,
                             VehicleID,
                             IsActive)
  
                        VALUES ( 
                             @OrderID,  
                             @StartTime,  
                             @VehicleArriveEstimate,
                             @EndTimeEstimate,  
                             @StartLocationLat,
                             @StartLocationLng,
                             @EndLocationLat,
                             @EndLocationLng,
                             @CustomerID,
                             @VehicleID,
                             @IsActive)  
                    END";
        }
    }
}
