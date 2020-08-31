using BP.ApiRepositories.Interfaces;
using BP.EntityRepositories;
using BP.Exceptions;
using BP.Models;
using BP.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BP.ApiRepositories
{
    public class ApiCustomerRepository : IApiCustomerRepository
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserIdentityRepository _userIdentityRepository;
        private readonly DecryptionService _passwordService;
        private readonly AuthenticationService _authenticationService;

        public ApiCustomerRepository(ICustomerRepository customerRepository, IUserIdentityRepository userIdentityRepository, DecryptionService passwordService, AuthenticationService authenticationService)
        {
            _customerRepository = customerRepository;
            _userIdentityRepository = userIdentityRepository;
            _passwordService = passwordService;
            _authenticationService = authenticationService;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            if (!_authenticationService.IsValidApiPassword(customer.ApiPassword))
            {
                throw new InvalidApiPasswordException();
            }
            customer.Role = Enums.RoleEnum.Customer;
            customer.PasswordSalt = Guid.NewGuid().ToString();
            customer.PasswordHash = _passwordService.Hash(customer.Password, customer.PasswordSalt);
            customer.UserIdentityID = (await _userIdentityRepository.AddUserIdentityAsync(customer)).UserIdentityID;
            await _customerRepository.AddCustomerAsync(customer);
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _customerRepository.GetCustomers();
        }

        public async Task MoveCustomerAsync(Customer customer)
        {
            await _customerRepository.MoveCustomerAsync(customer);
        }
    }
}
