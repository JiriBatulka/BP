using BP.Converters;
using BP.EntityRepositories;
using BP.Enums;
using BP.Models;
using BP.StoredProcedures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BP.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerConverter _customerConverter;
        private readonly CustomerSP _customerSP;
        public CustomerRepository(CustomerSP customerSP, CustomerConverter customerConverter)
        {
            _customerSP = customerSP;
            _customerConverter = customerConverter;
        }

        public async Task AddCustomerAsync(Models.Customer customer)
        {
            await _customerSP.AddCustomerAsync(_customerConverter.Convert(customer));
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _customerSP.GetCustomersAsync();
        }

        public async Task MoveCustomerAsync(Models.Customer customer)
        {
            await _customerSP.MoveCustomerAsync(_customerConverter.Convert(customer));
        }
    }
}

