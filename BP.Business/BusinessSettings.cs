namespace BP
{
    public class BusinessSettings
    {
        public virtual string PrivateEncryptionKey { get; }
        public virtual string PublicEncryptionKey { get; }
        public string JwtSecret { get; }

        public BusinessSettings() { }

        public BusinessSettings(string privateEncryptionKey, string publicEncryptionKey, string jwtSecret)
        {
            PrivateEncryptionKey = privateEncryptionKey;
            PublicEncryptionKey = publicEncryptionKey;
            JwtSecret = jwtSecret;
        }
    }
}
