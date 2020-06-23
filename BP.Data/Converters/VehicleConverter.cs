using System.Collections.Generic;
using System.Linq;

namespace BP.Converters
{
    public class VehicleConverter
    {
        public Entities.Vehicle Convert(Models.Vehicle vehicle)
        {
            return new Entities.Vehicle
            {
                AdultSeats = vehicle.AdultSeats,
                BootCapacity = vehicle.AdultSeats,
                Colour = vehicle.Colour,
                CurrentLat = vehicle.CurrentLat,
                CurrentLng = vehicle.CurrentLng,
                InfantSeats = vehicle.InfantSeats,
                IsShared = vehicle.IsShared,
                NumberPlate = vehicle.NumberPlate,
                Type = vehicle.Type,
                VehicleID = vehicle.VehicleID,
                IsActive = vehicle.IsActive
            };
        }
    }
}
