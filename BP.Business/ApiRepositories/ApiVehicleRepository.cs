using BP.ApiRepositories.Interfaces;
using BP.EntityRepositories;
using BP.Models;
using System.Threading.Tasks;

namespace BP.ApiRepositories
{
    public class ApiVehicleRepository : IApiVehicleRepository
    {
        private readonly IVehicleRepository _vehicleRepository;

        public ApiVehicleRepository(IVehicleRepository vehicleRepository)
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
