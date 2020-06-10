using System.Collections.Generic;
using System.Linq;

namespace BP.Converters
{
    internal class VehicleRentConverter
    {
        public Models.VehicleRent Convert(Entities.VehicleRent vehicleRent)
        {
            return new Models.VehicleRent
            {
                DriverId = vehicleRent.DriverId,
                TimeFrom = vehicleRent.TimeFrom,
                TimeUntil = vehicleRent.TimeUntil,
                VehicleId = vehicleRent.VehicleId,
                VehicleRentId = vehicleRent.VehicleRentId
            };
        }

        public IEnumerable<Models.VehicleRent> Convert(IEnumerable<Entities.VehicleRent> vehicleRents)
        {
            return vehicleRents.Select(x => Convert(x));
        }
    }
}
