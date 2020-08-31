using BP.DTOs.Converters;
using BP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BP.Repositories
{
    public class CustomerRepository
    {
        private readonly HttpClient _httpClient;
        private readonly CustomerDTOConverter _customerDTOConverter;

        public CustomerRepository(HttpClient httpClient, CustomerDTOConverter customerDTOConverter)
        {
            _httpClient = httpClient;
            _customerDTOConverter = customerDTOConverter;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            StringContent customerContent = new StringContent(JsonSerializer.Serialize(_customerDTOConverter.Convert(customer)), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/customer/add", customerContent);
        }
    }
}
