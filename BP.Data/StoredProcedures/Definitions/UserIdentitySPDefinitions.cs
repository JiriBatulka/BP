using System.Collections.Generic;

namespace BP.StoredProcedures.Definitions
{
    internal class UserIdentitySPDefinitions
    {
        public static Dictionary<string, string> Definitions { get; } = new Dictionary<string, string>();
        public static string AddUserIdentity { get; } = "[dbo].[AddUserIdentity]";
        public static string GetUserIdentityByUsername { get; } = "[dbo].[GetUserIdentityByUsername]";

        public static void CreateDefinitions()
        {
            CreateAddUserIdentity();
            CreateGetUserIdentityByUsername();
        }

        private static void CreateGetUserIdentityByUsername()
        {
            Definitions[GetUserIdentityByUsername] =
                $@"CREATE OR ALTER PROCEDURE {GetUserIdentityByUsername}
                        @Username nvarchar(255)
                    AS
                    BEGIN
                        SET NOCOUNT ON; 
						SELECT *
						FROM [dbo].UserIdentities
                        WHERE Username=@Username;
                    END";
        }

        private static void CreateAddUserIdentity()
        {
            Definitions[AddUserIdentity] =
                $@"CREATE OR ALTER PROCEDURE {AddUserIdentity}
                        @Username nvarchar(255),
                        @PasswordHash varbinary(255),
                        @PasswordSalt nvarchar(255),
                        @Role nvarchar(255),
                        @UserIdentityID uniqueidentifier OUTPUT
                    AS
                    BEGIN
                        SET NOCOUNT ON; 
						DECLARE @returnUserIdentityID TABLE (id uniqueidentifier);
                        INSERT INTO [dbo].[UserIdentities]  
                            (Username,  
                             PasswordHash,
                             PasswordSalt,
                             Role)
    				    OUTPUT inserted.UserIdentityID INTO @returnUserIdentityID
                        VALUES (@Username,  
                             @PasswordHash,
                             @PasswordSalt,
                             @Role);
                        SELECT @UserIdentityID = r.id from @returnUserIdentityID r;
                    END";
        }
    }
}
