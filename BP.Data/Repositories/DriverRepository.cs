using BP.Converters;
using BP.EntityRepositories;
using BP.Models;
using BP.StoredProcedures;
using System.Threading.Tasks;

namespace BP.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly DriverConverter _driverConverter;
        private readonly DriverSP _driverSP;
        public DriverRepository(DriverSP driverSP, DriverConverter driverConverter)
        {
            _driverSP = driverSP;
            _driverConverter = driverConverter;
        }

        public async Task AddDriverAsync(Driver driver)
        {
            await _driverSP.AddDriverAsync(_driverConverter.Convert(driver));
        }
    }
}
