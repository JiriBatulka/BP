namespace BP
{
    public class BusinessSettings
    {
        public string PrivateEncryptionKey { get; }
        public string PublicEncryptionKey { get; }
        public string JwtSecret { get; }
        public string ApiPassword { get; }

        public BusinessSettings(string privateEncryptionKey, string publicEncryptionKey, string jwtSecret, string apiPassword)
        {
            PrivateEncryptionKey = privateEncryptionKey;
            PublicEncryptionKey = publicEncryptionKey;
            JwtSecret = jwtSecret;
            ApiPassword = apiPassword;
        }
    }
}
