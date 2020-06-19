using System;
using System.Collections.Generic;
using System.Text;

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
                @"CREATE PROCEDURE [dbo].[AddDriver]
                        @DriverID uniqueidentifier,
                        @FirstName nvarchar(31),
                        @Surname nvarchar(31),
                        @PhoneNumber nvarchar(15)
                    AS
                    BEGIN
                        INSERT INTO [dbo].[Drivers]  
                            (DriverID,  
                             FirstName,  
                             Surname,  
                             PhoneNumber)
  
                        VALUES ( 
                             @DriverID,  
                             @FirstName,  
                             @Surname,  
                             @PhoneNumber)  
                    END";
        }
    }
}
