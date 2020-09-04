using BP.Simulation.DTOs;
using BP.Simulation.DTOs.Converters;
using BP.Simulation.Exceptions;
using BP.Simulation.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BP.Simulation.Repositories
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
            HttpResponseMessage response = await _httpClient.PostAsync($"api/customer/add", customerContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApiClientException(response.ReasonPhrase); 
            }
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            IEnumerable<CustomerDTO.GetCustomersDTO> response = await _httpClient.GetFromJsonAsync<IEnumerable<CustomerDTO.GetCustomersDTO>>($"api/customer/get");
            return _customerDTOConverter.Convert(response);
        }
    }
}
