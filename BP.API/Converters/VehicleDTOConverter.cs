using BP.DTOs;
using BP.Models;

namespace BP.Converters
{
    public class VehicleDTOConverter
    {
        public Vehicle Convert(VehicleDTO.AddVehicleDTO addVehicleDTO)
        {
            return new Vehicle
            {
                AdultSeats = addVehicleDTO.AdultSeats,
                BootCapacity = addVehicleDTO.BootCapacity,
                Colour = addVehicleDTO.Colour,
                InfantSeats = addVehicleDTO.InfantSeats,
                IsShared = addVehicleDTO.IsShared,
                NumberPlate = addVehicleDTO.NumberPlate,
                Type = addVehicleDTO.Type
            };
        }

        public Vehicle Convert(VehicleDTO.MoveVehicleDTO moveVehicleDTO)
        {
            return new Vehicle
            {
                VehicleID = moveVehicleDTO.VehicleID,
                CurrentLat = moveVehicleDTO.TargetLat,
                CurrentLng = moveVehicleDTO.TargetLng,
            };
        }
    }
}
