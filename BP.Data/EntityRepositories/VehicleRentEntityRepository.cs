using BP.Converters;
using BP.EntityRepositories;
using BP.Models;
using BP.StoredProcedures;
using System.Threading.Tasks;

namespace BP.EntityRepositories
{
    public class VehicleRentEntityRepository : IVehicleRentEntityRepository
    {
        private readonly VehicleRentConverter _vehicleRentConverter;
        private readonly VehicleRentSP _vehicleRentSP;
        public VehicleRentEntityRepository(VehicleRentSP vehicleRentSP, VehicleRentConverter vehicleRentConverter)
        {
            _vehicleRentSP = vehicleRentSP;
            _vehicleRentConverter = vehicleRentConverter;
        }

        public async Task AddVehicleRentAsync(VehicleRent vehicleRent)
        {
            await _vehicleRentSP.AddVehicleRentAsync(_vehicleRentConverter.Convert(vehicleRent));
        }
    }
}
