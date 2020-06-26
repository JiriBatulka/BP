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
    public class DriverRepository : IDriverRepository
    {
        private readonly DriverConverter driverConverter;
        private readonly DriverSP driverSP;
        public DriverRepository(DriverSP driverSP, DriverConverter driverConverter)
        {
            this.driverSP = driverSP;
            this.driverConverter = driverConverter;
        }

        public async Task<Guid> AddDriverAsync(Driver driver)
        {
            return await driverSP.AddDriverAsync(driverConverter.Convert(driver));
        }
    }
}
