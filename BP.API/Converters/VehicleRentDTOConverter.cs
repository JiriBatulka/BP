using BP.DTOs;
using BP.Models;

namespace BP.Converters
{
    public class VehicleRentDTOConverter
    {
        internal VehicleRent Convert(VehicleRentDTO.AddVehicleRentDTO addVehicleRentDTO)
        {
            return new VehicleRent
            {
                DriverID = addVehicleRentDTO.DriverID,
                IsOwned = addVehicleRentDTO.IsOwned,
                TimeFrom = addVehicleRentDTO.TimeFrom,
                TimeUntil = addVehicleRentDTO.TimeUntil,
                VehicleID = addVehicleRentDTO.VehicleID
            };
        }
    }
}
