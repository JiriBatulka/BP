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
                        @CustomerID uniqueidentifier,
                        @FirstName nvarchar(31),
                        @Surname nvarchar(31),
                        @PhoneNumber nvarchar(15),
                        @IsActive bit
                    AS
                    BEGIN
                        INSERT INTO [dbo].[Customers]  
                            (CustomerID,  
                             FirstName,  
                             Surname,  
                             PhoneNumber,
                             IsActive)
  
                        VALUES ( 
                             @CustomerID,  
                             @FirstName,  
                             @Surname,  
                             @PhoneNumber,
                             @IsActive)  
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
