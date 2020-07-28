using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BP.Converters
{
    public static class GenericConverter
    {
        //Just a working example, but it'll by slow because of the reflection and prone to errors
        //I'm using concrete converters instead
        [Obsolete]
        public static T Convert<T>(object value) where T : class, new()
        {
            var result = new T();
            PropertyInfo[] valueProperties = value.GetType().GetProperties();
            var resultType = result.GetType();
            foreach (PropertyInfo valueProperty in valueProperties)
            {
                if (resultType.GetProperty(valueProperty.Name) != null)
                {
                    PropertyInfo resultProperty = resultType.GetProperty(valueProperty.Name);
                    try
                    {
                        resultProperty.SetValue(result, valueProperty.GetValue(value));
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            return result;
        }
    }
}
