using BP.ApiRepositories.Interfaces;
using BP.EntityRepositories;
using BP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.ApiRepositories
{
    public class ApiCustomerRepository : IApiCustomerRepository
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserIdentityRepository _userIdentityRepository;

        public ApiCustomerRepository(ICustomerRepository customerRepository, IUserIdentityRepository userIdentityRepository)
        {
            _customerRepository = customerRepository;
            _userIdentityRepository = userIdentityRepository;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            customer.UserIdentityID = await _userIdentityRepository.AddUserIdentityAsync(customer);
            await _customerRepository.AddCustomerAsync(customer);
        }

        public async Task MoveCustomerAsync(Customer customer)
        {
            await _customerRepository.MoveCustomerAsync(customer);
        }
    }
}
