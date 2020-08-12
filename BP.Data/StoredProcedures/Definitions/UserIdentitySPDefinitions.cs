using System.Collections.Generic;

namespace BP.StoredProcedures.Definitions
{
    internal class UserIdentitySPDefinitions
    {
        public static Dictionary<string, string> Definitions = new Dictionary<string, string>();
        public static string AddUserIdentity = "AddUserIdentity";
        public static string GetHashSalt = "GetHashSalt";

        static UserIdentitySPDefinitions()
        {
            CreateAddUserIdentity();
            CreateGetHashSalt();
        }

        private static void CreateGetHashSalt()
        {
            Definitions[GetHashSalt] =
                @"CREATE OR ALTER PROCEDURE [dbo].[GetHashSalt]
                        @Username nvarchar(255),
                        @PasswordHash varbinary(255) OUTPUT,
                        @PasswordSalt nvarchar(255) OUTPUT
                    AS
                    BEGIN
                        SET NOCOUNT ON; 
						SET @PasswordHash = CONVERT(varbinary, 'PasswordHash')
                        SET @PasswordSalt = 'PasswordSalt'
                        SELECT @PasswordHash, @PasswordSalt from [dbo].[UserIdentities] where Username = @Username;
                    END";
        }

        private static void CreateAddUserIdentity()
        {
            Definitions[AddUserIdentity] =
                @"CREATE OR ALTER PROCEDURE [dbo].[AddUserIdentity]
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
