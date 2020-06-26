using System;
using System.Collections.Generic;
using System.Text;

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
