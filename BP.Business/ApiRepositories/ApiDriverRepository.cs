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
        private readonly IDriverRepository driverRepository;

        public ApiDriverRepository(IDriverRepository driverRepository)
        {
            this.driverRepository = driverRepository;
        }

        public async Task<Guid> AddDriverAsync(Driver driver)
        {
            return await driverRepository.AddDriverAsync(driver);
        }
    }
}
