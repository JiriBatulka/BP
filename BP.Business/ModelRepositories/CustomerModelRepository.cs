using BP.EntityRepositories;
using BP.Exceptions;
using BP.Models;
using BP.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BP.ModelRepositories
{
    public class CustomerModelRepository
    {
        private readonly EntityRepositories.ICustomerEntityRepository _customerRepository;
        private readonly IUserIdentityEntityRepository _userIdentityRepository;
        private readonly DecryptionService _decryptionService;
        private readonly AuthenticationService _authenticationService;

        public CustomerModelRepository(EntityRepositories.ICustomerEntityRepository customerRepository, IUserIdentityEntityRepository userIdentityRepository, DecryptionService decryptionService, AuthenticationService authenticationService)
        {
            _customerRepository = customerRepository;
            _userIdentityRepository = userIdentityRepository;
            _decryptionService = decryptionService;
            _authenticationService = authenticationService;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            customer.Role = Enums.RoleEnum.Customer;
            customer.PasswordSalt = Guid.NewGuid().ToString();
            customer.PasswordHash = _decryptionService.Hash(customer.Password, customer.PasswordSalt);
            customer.UserIdentityID = (await _userIdentityRepository.AddUserIdentityAsync(customer)).UserIdentityID;
            await _customerRepository.AddCustomerAsync(customer);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _customerRepository.GetCustomersAsync();
        }

        public async Task MoveCustomerAsync(Customer customer)
        {
            await _customerRepository.MoveCustomerAsync(customer);
        }
    }
}
