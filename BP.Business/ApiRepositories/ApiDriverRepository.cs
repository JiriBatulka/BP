using BP.ApiRepositories.Interfaces;
using BP.EntityRepositories;
using BP.Exceptions;
using BP.Models;
using BP.Services;
using System.Threading.Tasks;

namespace BP.ApiRepositories
{
    public class ApiDriverRepository : IApiDriverRepository
    {
        private readonly IDriverRepository _driverRepository;
        private readonly AuthenticationService _authenticationService;

        public ApiDriverRepository(IDriverRepository driverRepository, AuthenticationService authenticationService)
        {
            _driverRepository = driverRepository;
            _authenticationService = authenticationService;
        }

        public async Task AddDriverAsync(Driver driver)
        {
            if (!_authenticationService.IsValidApiPassword(driver.ApiPassword))
            {
                throw new InvalidApiPasswordException();
            }
            await _driverRepository.AddDriverAsync(driver);
        }
    }
}
