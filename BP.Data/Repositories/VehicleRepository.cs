using BP.Converters;
using BP.EntityRepositories;
using BP.StoredProcedures;
using System.Threading.Tasks;

namespace BP.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicleConverter _vehicleConverter;
        private readonly VehicleSP _vehicleSP;
        public VehicleRepository(VehicleSP vehicleSP, VehicleConverter vehicleConverter)
        {
            _vehicleSP = vehicleSP;
            _vehicleConverter = vehicleConverter;
        }

        public async Task AddVehicleAsync(Models.Vehicle vehicle)
        {
            await _vehicleSP.AddVehicleAsync(_vehicleConverter.Convert(vehicle));
        }

        public async Task MoveVehicleAsync(Models.Vehicle vehicle)
        {
            await _vehicleSP.MoveVehicleAsync(_vehicleConverter.Convert(vehicle));
        }
    }
}
