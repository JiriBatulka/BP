using BP.Simulation.DTOs.Converters;
using BP.Simulation.Exceptions;
using BP.Simulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BP.Simulation.Repositories
{
    public class UserRepository
    {
        private readonly HttpClient _httpClient;
        private readonly UserDTOConverter _userDTOConverter;

        public UserRepository(HttpClient httpClient, UserDTOConverter userDTOConverter)
        {
            _httpClient = httpClient;
            _userDTOConverter = userDTOConverter;
        }

        public async Task<User> GetAuthToken(User user)
        {
            StringContent customerContent = new StringContent(JsonSerializer.Serialize(_userDTOConverter.Convert(user)), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync($"api/useridentity/gettoken", customerContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApiClientException(response.ReasonPhrase);
            }
            user.AuthToken = response.Content.ToString();
            return user;
        }
    }
}
