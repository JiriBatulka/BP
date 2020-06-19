using BP.ApiRepositories.Interfaces;
using BP.EntityRepositories;
using BP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.ApiRepositories
{
    public class ApiDriverRepository : IApiDriverRepository
    {
        private IDriverRepository driverRepository;

        public ApiDriverRepository(IDriverRepository driverRepository)
        {
            this.driverRepository = driverRepository;
        }

        public Task<Guid> AddDriverAsync(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}
