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
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicleConverter vehicleConverter;
        private readonly VehicleSP vehicleSP;
        public VehicleRepository(VehicleSP vehicleSP, VehicleConverter vehicleConverter)
        {
            this.vehicleSP = vehicleSP;
            this.vehicleConverter = vehicleConverter;
        }

        public async Task<Guid> AddVehicleAsync(Models.Vehicle vehicle)
        {
            return await vehicleSP.AddVehicleAsync(vehicleConverter.Convert(vehicle));
        }

        public async Task MoveVehicleAsync(Models.Vehicle vehicle)
        {
            await vehicleSP.MoveVehicleAsync(vehicleConverter.Convert(vehicle));
        }
    }
}
