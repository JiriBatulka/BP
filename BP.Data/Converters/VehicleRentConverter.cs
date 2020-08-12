namespace BP.Converters
{
    public class VehicleRentConverter
    {
        public Entities.VehicleRent Convert(Models.VehicleRent vehicleRent)
        {
            return new Entities.VehicleRent
            {
                DriverID = vehicleRent.DriverID,
                TimeFrom = vehicleRent.TimeFrom,
                TimeUntil = vehicleRent.TimeUntil,
                VehicleID = vehicleRent.VehicleID,
                VehicleRentID = vehicleRent.VehicleRentID,
                IsOwned = vehicleRent.IsOwned
            };
        }
    }
}
