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
        private ICustomerRepository customerRepository;

        public ApiCustomerRepository(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<Guid> AddCustomerAsync(Customer customer)
        {
            customer.IsActive = true;
            return await customerRepository.AddCustomerAsync(customer);
        }
        public async Task<bool> MoveCustomerAsync(Customer customer)
        {
            return await customerRepository.MoveCustomerAsync(customer);
        }
    }
}
