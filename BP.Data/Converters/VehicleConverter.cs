using System.Collections.Generic;
using System.Linq;

namespace BP.Converters
{
    internal class VehicleConverter
    {
        public Models.Vehicle Convert(Entities.Vehicle vehicle)
        {
            return new Models.Vehicle
            {
                AdultSeats = vehicle.AdultSeats,
                BootCapacity = vehicle.AdultSeats,
                Colour = vehicle.Colour,
                CurrentLat = vehicle.CurrentLat,
                CurrentLng = vehicle.CurrentLng,
                DriverId = vehicle.DriverId,
                InfantSeats = vehicle.InfantSeats,
                IsShared = vehicle.IsShared,
                Spz = vehicle.Spz,
                Type = vehicle.Type,
                VehicleId = vehicle.VehicleId,
            };
        }

        public IEnumerable<Models.Vehicle> Convert(IEnumerable<Entities.Vehicle> vehicles)
        {
            return vehicles.Select(x => Convert(x));
        }
    }
}
