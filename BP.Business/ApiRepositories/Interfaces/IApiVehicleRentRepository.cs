using BP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.ApiRepositories.Interfaces
{
    public interface IApiVehicleRentRepository
    {
        public Task<Guid> AddVehicleRentAsync(VehicleRent vehicleRent);
    }
}
