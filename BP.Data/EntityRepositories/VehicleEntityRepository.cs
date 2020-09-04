using BP.Converters;
using BP.EntityRepositories;
using BP.StoredProcedures;
using System.Threading.Tasks;

namespace BP.EntityRepositories
{
    public class VehicleEntityRepository : IVehicleEntityRepository
    {
        private readonly VehicleConverter _vehicleConverter;
        private readonly VehicleSP _vehicleSP;
        public VehicleEntityRepository(VehicleSP vehicleSP, VehicleConverter vehicleConverter)
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
