using BP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.EntityRepositories
{
    public interface IVehicleRentRepository
    {
        public Task AddVehicleRentAsync(VehicleRent vehicleRent);
    }
}
