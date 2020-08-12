using BP.ApiRepositories.Interfaces;
using BP.EntityRepositories;
using BP.Models;
using BP.Services;
using System;
using System.Threading.Tasks;

namespace BP.ApiRepositories
{
    public class ApiCustomerRepository : IApiCustomerRepository
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserIdentityRepository _userIdentityRepository;
        private readonly PasswordService _passwordService;

        public ApiCustomerRepository(ICustomerRepository customerRepository, IUserIdentityRepository userIdentityRepository, PasswordService passwordService)
        {
            _customerRepository = customerRepository;
            _userIdentityRepository = userIdentityRepository;
            _passwordService = passwordService;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            customer.DecryptedPassword = _passwordService.Decrypt(customer.EncryptedPassword);
            customer.Role = Enums.RoleEnum.Customer;
            customer.PasswordSalt = Guid.NewGuid().ToString();
            customer.PasswordHash = _passwordService.Hash(customer.DecryptedPassword, customer.PasswordSalt);
            customer.UserIdentityID = (await _userIdentityRepository.AddUserIdentityAsync(customer)).UserIdentityID;
            await _customerRepository.AddCustomerAsync(customer);
        }

        public async Task MoveCustomerAsync(Customer customer)
        {
            await _customerRepository.MoveCustomerAsync(customer);
        }
    }
}
