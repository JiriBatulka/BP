using System;
using System.Collections.Generic;
using System.Text;

namespace BP.StoredProcedures.Definitions
{
    internal class UserIdentitySPDefinitions
    {
        public static Dictionary<string, string> Definitions = new Dictionary<string, string>();
        public static string AddUserIdentity = "AddUserIdentity";

        static UserIdentitySPDefinitions()
        {
            CreateAddUserIdentity();
        }

        private static void CreateAddUserIdentity()
        {
            Definitions[AddUserIdentity] =
                @"CREATE PROCEDURE [dbo].[AddUserIdentity]
                        @Username nvarchar(127),
                        @Password nvarchar(127),
                        @Role nvarchar(31)
                        @UserIdentityID uniqueidentifier OUTPUT
                    AS
                    BEGIN
                        SET NOCOUNT ON; 
						DECLARE @returnUserIdentityID TABLE (id uniqueidentifier);
                        INSERT INTO [dbo].[UserIdentities]  
                            (Username,  
                             Password,
                             Role)
    				    OUTPUT inserted.UserIdentityID INTO @returnUserIdentityID
                        VALUES (@Username,  
                             @Password,
                             @Role);
                        SELECT @UserIdentityID = r.id from @returnOrderID r;
                    END";
        }
    }
}
