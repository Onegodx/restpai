using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using Azure;
using Lab3.Models;
using Lab4.Models;

namespace Lab4.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PriceList>> GetPriceListsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<PriceList>>("api/pricelists");
        }

        public async Task<Response> LoginAsync(User user)
        {
            var response = await _httpClient.PostAsJsonAsync("api/login", user);
            return await response.Content.ReadFromJsonAsync<Response>();
        }

        public async Task<Sales> CreateSaleAsync(Sales sale)
        {
            var response = await _httpClient.PostAsJsonAsync("api/sales", sale);
            return await response.Content.ReadFromJsonAsync<Sales>();
        }

    }
}