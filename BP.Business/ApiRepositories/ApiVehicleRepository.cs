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
        private IVehicleRepository vehicleRepository;

        public ApiVehicleRepository(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public Task<Guid> AddVehicleAsync(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public Task MoveVehicleAsync(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
