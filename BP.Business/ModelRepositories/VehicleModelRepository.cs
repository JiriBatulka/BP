using BP.EntityRepositories;
using BP.Models;
using System.Threading.Tasks;

namespace BP.ModelRepositories
{
    public class VehicleModelRepository
    {
        private readonly EntityRepositories.IVehicleEntityRepository _vehicleRepository;

        public VehicleModelRepository(EntityRepositories.IVehicleEntityRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task AddVehicleAsync(Vehicle vehicle)
        {
            await _vehicleRepository.AddVehicleAsync(vehicle);
        }

        public async Task MoveVehicleAsync(Vehicle vehicle)
        {
            await _vehicleRepository.MoveVehicleAsync(vehicle);
        }
    }
}
