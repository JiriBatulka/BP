using BP.DTOs;
using BP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.Converters
{
    public class VehicleRentConverter
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
