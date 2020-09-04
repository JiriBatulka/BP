using System.Collections.Generic;

namespace BP.StoredProcedures.Definitions
{
    internal class DriverSPDefinitions
    {
        public static Dictionary<string, string> Definitions { get; } = new Dictionary<string, string>();
        public static string AddDriver { get; } = "AddDriver";

        public static void CreateDefinitions()
        {
            CreateAddDriver();
        }

        private static void CreateAddDriver()
        {
            Definitions["AddDriver"] =
                $@"CREATE OR ALTER PROCEDURE [dbo].[{AddDriver}]
                        @FirstName nvarchar(255),
                        @Surname nvarchar(255),
                        @PhoneNumber nvarchar(255),
                        @Email nvarchar(255),
                        @UserIdentityID uniqueidentifier
                    AS
                    BEGIN
                        SET NOCOUNT ON; 
                        INSERT INTO [dbo].[Drivers]  
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
    }
}
