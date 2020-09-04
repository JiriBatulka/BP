using BP.EntityRepositories;
using BP.Models;
using System.Threading.Tasks;

namespace BP.ModelRepositories
{
    public class VehicleRentModelRepository
    {
        private readonly EntityRepositories.IVehicleRentEntityRepository _vehicleRentRepository;

        public VehicleRentModelRepository(EntityRepositories.IVehicleRentEntityRepository vehicleRentRepository)
        {
            _vehicleRentRepository = vehicleRentRepository;
        }

        public async Task AddVehicleRentAsync(VehicleRent vehicleRent)
        {
            await _vehicleRentRepository.AddVehicleRentAsync(vehicleRent);
        }
    }
}
