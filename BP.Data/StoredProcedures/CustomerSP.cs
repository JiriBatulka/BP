using BP.Entities;
using BP.StoredProcedures.Definitions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.StoredProcedures
{
    public class CustomerSP
    {
        private readonly BPContext BPContext;
        public CustomerSP(BPContext BPContext)
        {
            this.BPContext = BPContext;
        }

        public async Task<bool> AddCustomerAsync(Customer customer)
        {
            //await BPContext.Database.ExecuteSqlCommandAsync($"EXECUTE {CustomerSPDefinitions.AddCustomer} \'{customer.CustomerID}\', \'{customer.FirstName}\', \'{customer.Surname}\', \'{customer.PhoneNumber}\', \'{customer.IsActive}\'");
            BPContext.Customers.Add(customer);
            BPContext.SaveChanges();
            return true;
        }

        public async Task<bool> MoveCustomerAsync(Customer customer)
        {
            return await BPContext.Customers.FromSqlRaw($"EXECUTE {CustomerSPDefinitions.MoveCustomer} \'{customer.CustomerID}\', \'{customer.CurrentLat}\', \'{customer.CurrentLng}\'").AnyAsync();
        }
    }
}