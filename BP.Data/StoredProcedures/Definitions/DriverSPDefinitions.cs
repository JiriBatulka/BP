using System.Collections.Generic;

namespace BP.StoredProcedures.Definitions
{
    internal class DriverSPDefinitions
    {
        public static Dictionary<string, string> Definitions = new Dictionary<string, string>();
        public static string AddDriver = "AddDriver";

        static DriverSPDefinitions()
        {
            CreateAddDriver();
        }

        private static void CreateAddDriver()
        {
            Definitions["AddDriver"] =
                @"CREATE OR ALTER PROCEDURE [dbo].[AddDriver]
                        @FirstName nvarchar(255),
                        @Surname nvarchar(255),
                        @PhoneNumber nvarchar(255)
                    AS
                    BEGIN
                        SET NOCOUNT ON; 
                        INSERT INTO [dbo].[Drivers]  
                            (FirstName,  
                             Surname,  
                             PhoneNumber)
                        VALUES (@FirstName,  
                             @Surname,  
                             @PhoneNumber);
                    END";
        }
    }
}
