using System.Collections.Generic;

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
                    @"CREATE OR ALTER PROCEDURE [dbo].[AddCustomer]
                        @FirstName nvarchar(255),
                        @Surname nvarchar(255),
                        @PhoneNumber nvarchar(255),
                        @Email nvarchar(255),
                        @Email nvarchar(255)
                    AS
                    BEGIN
                        SET NOCOUNT ON; 
                        INSERT INTO [dbo].[Customers]  
                            (FirstName,  
                             Surname,  
                             PhoneNumber)
                        VALUES (@FirstName,  
                             @Surname,  
                             @PhoneNumber);
                    END";
        }

        private static void CreateMoveCustomer()
        {
            Definitions[MoveCustomer] =
            @"CREATE OR ALTER PROCEDURE [dbo].[MoveCustomer]
                        @CustomerID uniqueidentifier,
                        @CurrentLat float,
                        @CurrentLng float
                    AS
                    BEGIN
                        SET NOCOUNT ON; 
                        UPDATE [dbo].[Customers]
                        SET CurrentLat = @CurrentLat, CurrentLng = @CurrentLng
                        WHERE CustomerID = @CustomerID
                    END";
        }
    }
}
