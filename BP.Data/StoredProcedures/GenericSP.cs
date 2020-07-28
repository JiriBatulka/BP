using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BP.StoredProcedures
{
    public class GenericSP
    {
        private readonly DataSettings _dataSettings;
        public GenericSP(DataSettings dataSettings)
        {
            _dataSettings = dataSettings;
        }

        //This works only because of the conventions I'm using
        //Also it'll be slow because of the reflection, so I'm using concrete procedures instead
        [Obsolete]
        public async Task<Guid> AddAsync(object entity)
        {
            Type entityType = entity.GetType();
            string entityTypeName = entityType.Name;
            PropertyInfo[] entityProperties = entity.GetType().GetProperties();

            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            conn.ConnectionString = _dataSettings.ConnectionString;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = $"Add{entityTypeName}";

            foreach (PropertyInfo entityProperty in entityProperties)
            {
                if (entityProperty.Name == $"{entityTypeName}ID")
                    continue;
                object propertyValue = entityProperty.GetValue(entity);

                if (propertyValue == null)
                    continue;

                cmd.Parameters.AddWithValue("@{entityProperty.Name}", propertyValue);
            }

            cmd.Parameters.Add($"@{entityTypeName}ID", SqlDbType.UniqueIdentifier);
            cmd.Parameters[$"@{entityTypeName}ID"].Direction = ParameterDirection.Output;

            try
            {
                conn.Open();
                await cmd.ExecuteNonQueryAsync();
                return (Guid)cmd.Parameters[$"@{entityTypeName}ID"].Value;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
