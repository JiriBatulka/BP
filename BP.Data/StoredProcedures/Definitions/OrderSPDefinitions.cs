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
                        @StartTime datetime2(7),
                        @VehicleArriveEstimate datetime2(7),
                        @EndTimeEstimate datetime2(7),
                        @StartLocationLat float,
                        @StartLocationLng float,
                        @EndLocationLat float,
                        @EndLocationLng float,
                        @CustomerID uniqueidentifier,
                        @VehicleID uniqueidentifier,
                        @OrderID uniqueidentifier OUTPUT
                    AS
                    BEGIN
                        SET NOCOUNT ON; 
						DECLARE @returnOrderID TABLE (id uniqueidentifier);
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
    				    OUTPUT inserted.OrderID INTO @returnOrderID
                        VALUES (@StartTime,  
                             @VehicleArriveEstimate,
                             @EndTimeEstimate,  
                             @StartLocationLat,
                             @StartLocationLng,
                             @EndLocationLat,
                             @EndLocationLng,
                             @CustomerID,
                             @VehicleID);
                        SELECT @OrderID = r.id from @returnOrderID r;
                    END";
        }
    }
}
