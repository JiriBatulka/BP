using BP.EntityRepositories;
using BP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.ApiRepositories
{
    public class ApiCustomerRepository
    {
        private ICustomerRepository customerRepository;

        public ApiCustomerRepository(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<Guid> AddCustomerAsync(Customer customer)
        {
            return await customerRepository.AddCustomerAsync(customer);
        }
        public async Task MoveCustomerAsync(Customer customer)
        {
            await customerRepository.MoveCustomerAsync(customer);
        }
    }
}
