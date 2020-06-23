using BP.Entities;
using BP.StoredProcedures.Definitions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.StoredProcedures
{
    public class VehicleSP
    {
        private readonly BPContext BPContext;
        public VehicleSP(BPContext BPContext)
        {
            this.BPContext = BPContext;
        }

        public async Task<bool> AddVehicleAsync(Vehicle vehicle)
        {
            return await BPContext.Customers.FromSqlRaw($"EXECUTE {VehicleSPDefinitions.AddVehicle} \'{vehicle.VehicleID}\', \'{vehicle.Type}\', \'{vehicle.NumberPlate}\', \'{vehicle.Colour}\', \'{vehicle.AdultSeats}\', \'{vehicle.InfantSeats}\', \'{vehicle.BootCapacity}\', \'{vehicle.IsShared}\', \'{vehicle.IsActive}\'").AnyAsync();
        }
        public async Task<bool> MoveVehicleAsync(Vehicle vehicle)
        {
            return await BPContext.Customers.FromSqlRaw($"EXECUTE {VehicleSPDefinitions.MoveVehicle} \'{vehicle.VehicleID}\', \'{vehicle.CurrentLat}\', \'{vehicle.CurrentLng}\'").AnyAsync(); 
        }
    }
}
