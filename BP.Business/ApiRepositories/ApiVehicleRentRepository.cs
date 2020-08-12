using BP.ApiRepositories.Interfaces;
using BP.EntityRepositories;
using BP.Models;
using System.Threading.Tasks;

namespace BP.ApiRepositories
{
    public class ApiVehicleRentRepository : IApiVehicleRentRepository
    {
        private readonly IVehicleRentRepository _vehicleRentRepository;

        public ApiVehicleRentRepository(IVehicleRentRepository vehicleRentRepository)
        {
            _vehicleRentRepository = vehicleRentRepository;
        }

        public async Task AddVehicleRentAsync(VehicleRent vehicleRent)
        {
            await _vehicleRentRepository.AddVehicleRentAsync(vehicleRent);
        }
    }
}
