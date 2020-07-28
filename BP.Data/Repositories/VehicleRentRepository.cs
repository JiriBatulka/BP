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
        private readonly VehicleRentConverter _vehicleRentConverter;
        private readonly VehicleRentSP _vehicleRentSP;
        public VehicleRentRepository(VehicleRentSP vehicleRentSP, VehicleRentConverter vehicleRentConverter)
        {
            _vehicleRentSP = vehicleRentSP;
            _vehicleRentConverter = vehicleRentConverter;
        }

        public async Task AddVehicleRentAsync(VehicleRent vehicleRent)
        {
            await _vehicleRentSP.AddVehicleRentAsync(_vehicleRentConverter.Convert(vehicleRent));
        }
    }
}
