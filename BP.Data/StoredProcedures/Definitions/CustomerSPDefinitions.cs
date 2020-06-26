using System;
using System.Collections.Generic;
using System.Text;

namespace BP.StoredProcedures.Definitions
{
    internal class CustomerSPDefinitions
    {
        public static Dictionary<string, string> Definitions = new Dictionary<string, string>();

        public static string AddCustomer = "AddCustomer";
        public static string MoveCustomer = "MoveCustomer";

        static CustomerSPDefinitions()
        {
            CreateAddCustomer();
            CreateMoveCustomer();
        }

        private static void CreateAddCustomer()
        {
            Definitions[AddCustomer] =
                    @"CREATE PROCEDURE [dbo].[AddCustomer]
                        @FirstName nvarchar(31),
                        @Surname nvarchar(31),
                        @PhoneNumber nvarchar(15),
                        @CustomerID uniqueidentifier OUTPUT
                    AS
                    BEGIN
                        SET NOCOUNT ON; 
						DECLARE @returnCustomerID TABLE (id uniqueidentifier);
                        INSERT INTO [dbo].[Customers]  
                            (FirstName,  
                             Surname,  
                             PhoneNumber)
						OUTPUT inserted.CustomerID INTO @returnCustomerID
                        VALUES (@FirstName,  
                             @Surname,  
                             @PhoneNumber);
						SELECT @CustomerID = r.id from @returnCustomerID r;
                    END";
        }

        private static void CreateMoveCustomer()
        {
            Definitions[MoveCustomer] =
            @"CREATE PROCEDURE [dbo].[MoveCustomer]
                        @CustomerID uniqueidentifier,
                        @CurrentLat float,
                        @CurrentLng float
                    AS
                    BEGIN
                        UPDATE [dbo].[Customers]
                        SET CurrentLat = @CurrentLat, CurrentLng = @CurrentLng
                        WHERE CustomerID = @CustomerID
                    END";
        }
    }
}
