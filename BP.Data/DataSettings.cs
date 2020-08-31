namespace BP
{
    public class DataSettings
    {
        public string ConnectionString { get; }
        public DataSettings(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
