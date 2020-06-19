using BP.ApiRepositories.Interfaces;
using BP.EntityRepositories;
using BP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.ApiRepositories
{
    public class ApiVehicleRentRepository : IApiVehicleRentRepository
    {
        private IVehicleRentRepository vehicleRentRepository;

        public ApiVehicleRentRepository(IVehicleRentRepository vehicleRentRepository)
        {
            this.vehicleRentRepository = vehicleRentRepository;
        }

        public Task<Guid> AddVehicleRentAsync(VehicleRent vehicleRent)
        {
            throw new NotImplementedException();
        }
    }
}
