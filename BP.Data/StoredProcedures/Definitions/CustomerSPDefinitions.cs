using System;
using System.Collections.Generic;

namespace BP.StoredProcedures.Definitions
{
    internal class CustomerSPDefinitions
    {
        public static Dictionary<string, string> Definitions { get; } = new Dictionary<string, string>();

        public static string AddCustomer { get; } = "[dbo].[AddCustomer]";
        public static string MoveCustomer { get; } = "[dbo].[MoveCustomer]";
        public static string GetCustomerIDByUserIdentityID { get; } = "[dbo].[GetCustomerIDByUserIdentityID]";

        static CustomerSPDefinitions()
        {
            CreateAddCustomer();
            CreateMoveCustomer();
            CreateGetCustomerByUserIdentityID();
        }

        private static void CreateGetCustomerByUserIdentityID()
        {
            Definitions[GetCustomerIDByUserIdentityID] =
                    $@"CREATE OR ALTER PROCEDURE {GetCustomerIDByUserIdentityID}
                        @UserIdentityID uniqueidentifier
                    AS
                    BEGIN
                        SET NOCOUNT ON; 
                        SELECT CustomerID
                        FROM [dbo].[Customers]  
                        WHERE UserIdentityID = @UserIdentityID
                    END";
        }

        private static void CreateAddCustomer()
        {
            Definitions[AddCustomer] =
                    $@"CREATE OR ALTER PROCEDURE {AddCustomer}
                        @FirstName nvarchar(255),
                        @Surname nvarchar(255),
                        @PhoneNumber nvarchar(255),
                        @Email nvarchar(255),
                        @UserIdentityID uniqueidentifier
                    AS
                    BEGIN
                        SET NOCOUNT ON; 
                        INSERT INTO [dbo].[Customers]  
                            (FirstName,  
                             Surname,  
                             PhoneNumber, 
                             Email, 
                             UserIdentityID)
                        VALUES (@FirstName,  
                             @Surname,  
                             @PhoneNumber,  
                             @Email,   
                             @UserIdentityID);
                    END";
        }

        private static void CreateMoveCustomer()
        {
            Definitions[MoveCustomer] =
            $@"CREATE OR ALTER PROCEDURE [dbo].[{MoveCustomer}]
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
