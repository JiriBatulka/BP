using System.Collections.Generic;
using System.Linq;

namespace BP.Converters
{
    public class DriverConverter
    {
        public Entities.Driver Convert(Models.Driver driver)
        {
            return new Entities.Driver
            {
                DriverID = driver.DriverID,
                FirstName = driver.FirstName,
                Surname = driver.Surname
            };
        }
    }
}
