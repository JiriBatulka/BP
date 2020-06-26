using BP.ApiRepositories.Interfaces;
using BP.EntityRepositories;
using BP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.ApiRepositories
{
    public class ApiVehicleRepository : IApiVehicleRepository
    {
        private readonly IVehicleRepository vehicleRepository;

        public ApiVehicleRepository(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public async Task<Guid> AddVehicleAsync(Vehicle vehicle)
        {
            return await vehicleRepository.AddVehicleAsync(vehicle);
        }

        public async Task MoveVehicleAsync(Vehicle vehicle)
        {
            await vehicleRepository.MoveVehicleAsync(vehicle);
        }
    }
}
