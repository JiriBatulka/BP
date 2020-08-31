using System.Collections.Generic;

namespace BP.StoredProcedures.Definitions
{
    internal class OrderSPDefinitions
    {
        public static Dictionary<string, string> Definitions { get; } = new Dictionary<string, string>();
        public static string AddOrder { get; } = "AddOrder";

        static OrderSPDefinitions()
        {
            CreateAddOrder();
        }

        private static void CreateAddOrder()
        {
            Definitions[AddOrder] =
                $@"CREATE OR ALTER PROCEDURE [dbo].[{AddOrder}]
                        @StartTime datetime2(7),
                        @VehicleArriveEstimate datetime2(7),
                        @EndTimeEstimate datetime2(7),
                        @StartLocationLat float,
                        @StartLocationLng float,
                        @EndLocationLat float,
                        @EndLocationLng float,
                        @CustomerID uniqueidentifier,
                        @VehicleID uniqueidentifier
                    AS
                    BEGIN
                        SET NOCOUNT ON; 
                        INSERT INTO [dbo].[Orders]  
                            (StartTime,  
                             VehicleArriveEstimate,
                             EndTimeEstimate,
                             StartLocationLat,
                             StartLocationLng,
                             EndLocationLat,
                             EndLocationLng,
                             CustomerID,
                             VehicleID)
                        VALUES (@StartTime,  
                             @VehicleArriveEstimate,
                             @EndTimeEstimate,  
                             @StartLocationLat,
                             @StartLocationLng,
                             @EndLocationLat,
                             @EndLocationLng,
                             @CustomerID,
                             @VehicleID);
                    END";
        }
    }
}
