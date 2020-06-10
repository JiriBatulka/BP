using System.Collections.Generic;
using System.Linq;

namespace BP.Converters
{
    internal class DriverConverter
    {
        public Models.Driver Convert(Entities.Driver driver)
        {
            return new Models.Driver
            {
                DriverId = driver.DriverId,
                FirstName = driver.FirstName,
                Surname = driver.Surname
            };
        }

        public IEnumerable<Models.Driver> Convert(IEnumerable<Entities.Driver> drivers)
        {
            return drivers.Select(x => Convert(x));
        }
    }
}
