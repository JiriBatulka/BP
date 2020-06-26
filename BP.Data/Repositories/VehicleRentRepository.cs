using BP.Converters;
using BP.EntityRepositories;
using BP.Models;
using BP.StoredProcedures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.Repositories
{
    public class VehicleRentRepository : IVehicleRentRepository
    {
        private readonly VehicleRentConverter vehicleRentConverter;
        private readonly VehicleRentSP vehicleRentSP;
        public VehicleRentRepository(VehicleRentSP vehicleRentSP, VehicleRentConverter vehicleRentConverter)
        {
            this.vehicleRentSP = vehicleRentSP;
            this.vehicleRentConverter = vehicleRentConverter;
        }

        public async Task<Guid> AddVehicleRentAsync(VehicleRent vehicleRent)
        {
            return await vehicleRentSP.AddVehicleRentAsync(vehicleRentConverter.Convert(vehicleRent));
        }
    }
}
