using BP.Entities;
using BP.StoredProcedures.Definitions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.StoredProcedures
{
    public class OrderSP
    {
        private readonly BPContext BPContext;
        public OrderSP(BPContext BPContext)
        {
            this.BPContext = BPContext;
        }

        public async Task<bool> AddOrderAsync(Order order)
        {
            return await BPContext.Orders.FromSqlRaw($"EXECUTE {OrderSPDefinitions.AddOrder} \'{order.OrderID}\', \'{order.StartTime}\', \'{order.VehicleArriveEstimate}\', \'{order.EndTimeEstimate}\', \'{order.StartLocationLat}\', \'{order.StartLocationLng}\', \'{order.EndLocationLat}\', \'{order.EndLocationLng}\', \'{order.CustomerID}\', \'{order.VehicleID}\', \'{order.IsActive}\'").AnyAsync();
        }
    }
}
