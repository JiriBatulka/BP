using BP.Entities;
using BP.StoredProcedures.Definitions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.StoredProcedures
{
    public class VehicleRentSP
    {
        private readonly BPContext BPContext;
        public VehicleRentSP(BPContext BPContext)
        {
            this.BPContext = BPContext;
        }

        public async Task<bool> AddVehicleRentAsync(VehicleRent vehicleRent)
        {
            return await BPContext.Orders.FromSqlRaw($"EXECUTE {VehicleRentSPDefinitions.AddVehicleRent} \'{vehicleRent.VehicleRentID}\', \'{vehicleRent.TimeFrom}\', \'{vehicleRent.TimeUntil}\', \'{vehicleRent.IsOwned}\', \'{vehicleRent.VehicleID}\', \'{vehicleRent.DriverID}\'").AnyAsync();
        }
    }
}
