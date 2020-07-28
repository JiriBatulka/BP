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
        private readonly IDriverRepository _driverRepository;

        public ApiDriverRepository(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task AddDriverAsync(Driver driver)
        {
            await _driverRepository.AddDriverAsync(driver);
        }
    }
}
