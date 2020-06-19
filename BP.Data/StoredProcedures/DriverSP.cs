using BP.Entities;
using BP.StoredProcedures.Definitions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.StoredProcedures
{
    public class DriverSP
    {
        private readonly BPContext BPContext;
        public DriverSP(BPContext BPContext)
        {
            this.BPContext = BPContext;
        }

        public async Task<bool> AddDriverAsync(Driver driver)
        {
            return await BPContext.Customers.FromSqlRaw($"EXECUTE {DriverSPDefinitions.AddDriver} \'{driver.DriverID}\', \'{driver.FirstName}\', \'{driver.Surname}\', \'{driver.PhoneNumber}\'").AnyAsync();
        }
    }
}

