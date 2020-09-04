namespace BP
{
    public class BusinessSettings
    {
        public string PrivateEncryptionKey { get; }
        public string PublicEncryptionKey { get; }
        public string JwtSecret { get; }

        public BusinessSettings(string privateEncryptionKey, string publicEncryptionKey, string jwtSecret)
        {
            PrivateEncryptionKey = privateEncryptionKey;
            PublicEncryptionKey = publicEncryptionKey;
            JwtSecret = jwtSecret;
        }
    }
}
