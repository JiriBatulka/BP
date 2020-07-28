﻿using BP.Converters;
using BP.Entities;
using BP.EntityRepositories;
using BP.StoredProcedures;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task MoveCustomerAsync(Models.Customer customer)
        {
            await _customerSP.MoveCustomerAsync(_customerConverter.Convert(customer));
        }
    }
}
