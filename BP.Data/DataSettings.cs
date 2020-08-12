namespace BP
{
    public class DataSettings
    {
        public string ConnectionString { get; set; }
        public DataSettings(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
