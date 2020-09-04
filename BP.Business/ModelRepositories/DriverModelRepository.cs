using BP.EntityRepositories;
using BP.Exceptions;
using BP.Models;
using BP.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BP.ModelRepositories
{
    public class DriverModelRepository
    {
        private readonly IDriverEntityRepository _driverRepository;
        private readonly AuthenticationService _authenticationService;
        private readonly DecryptionService _decryptionService;
        private readonly IUserIdentityEntityRepository _userIdentityRepository;

        public DriverModelRepository(IDriverEntityRepository driverRepository, AuthenticationService authenticationService, DecryptionService decryptionService, IUserIdentityEntityRepository userIdentityRepository)
        {
            _driverRepository = driverRepository;
            _authenticationService = authenticationService;
            _decryptionService = decryptionService;
            _userIdentityRepository = userIdentityRepository;
        }

        public async Task AddDriverAsync(Driver driver)
        {
            driver.Role = Enums.RoleEnum.Driver;
            driver.PasswordSalt = Guid.NewGuid().ToString();
            driver.PasswordHash = _decryptionService.Hash(driver.Password, driver.PasswordSalt);
            driver.UserIdentityID = (await _userIdentityRepository.AddUserIdentityAsync(driver)).UserIdentityID;
            await _driverRepository.AddDriverAsync(driver);
        }

        public Task<List<Driver>> GetDriversAsync()
        {
            throw new NotImplementedException();
        }
    }
}
