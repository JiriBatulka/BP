namespace BP
{
    public class BusinessSettings
    {
        public string PrivateEncryptionKey { get; set; }
        public string PublicEncryptionKey { get; set; }

        public BusinessSettings(string privateEncryptionKey, string publicEncryptionKey)
        {
            PrivateEncryptionKey = privateEncryptionKey;
            PublicEncryptionKey = publicEncryptionKey;
        }
    }
}
