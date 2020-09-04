using BP.Converters;
using BP.EntityRepositories;
using BP.Models;
using BP.StoredProcedures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BP.EntityRepositories
{
    public class CustomerEntityRepository : ICustomerEntityRepository
    {
        private readonly CustomerConverter _customerConverter;
        private readonly CustomerSP _customerSP;
        public CustomerEntityRepository(CustomerSP customerSP, CustomerConverter customerConverter)
        {
            _customerSP = customerSP;
            _customerConverter = customerConverter;
        }

        public async Task AddCustomerAsync(Models.Customer customer)
        {
            await _customerSP.AddCustomerAsync(_customerConverter.Convert(customer));
        }


        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return _customerConverter.Convert(await _customerSP.GetCustomersAsync());
        }


        public async Task MoveCustomerAsync(Models.Customer customer)
        {
            await _customerSP.MoveCustomerAsync(_customerConverter.Convert(customer));
        }

    }
}

