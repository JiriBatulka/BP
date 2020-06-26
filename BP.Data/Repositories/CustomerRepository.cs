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
        private readonly CustomerConverter customerConverter;
        private readonly CustomerSP customerSP;
        public CustomerRepository(CustomerSP customerSP, CustomerConverter customerConverter)
        {
            this.customerSP = customerSP;
            this.customerConverter = customerConverter;
        }

        public async Task<Guid> AddCustomerAsync(Models.Customer customer)
        {
            return await customerSP.AddCustomerAsync(customerConverter.Convert(customer));
        }

        public async Task MoveCustomerAsync(Models.Customer customer)
        {
            await customerSP.MoveCustomerAsync(customerConverter.Convert(customer));
        }
    }
}
