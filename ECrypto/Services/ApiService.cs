using ECrypto.Models;
using ECrypto.Services.ApiEndpoints;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace ECrypto.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(ApiEndPoints.BaseEndpoint);
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Console Application");
            _httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Currency>> GetCurrenciesAsync(int count = -1)
        {
            string requestUri = ApiEndPoints.Assets;

            if (count > 0) requestUri = requestUri + $"?limit={count}";

            HttpResponseMessage response = await _httpClient.GetAsync(requestUri).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var res = await response.Content.ReadAsStringAsync();

            var rootJson = JsonConvert.DeserializeObject<JsonArray<Currency>>(res);

            return rootJson.Data;
        }

        public async Task<Currency> GetCurrencyAsync(string id)
        {
            string requestUri = ApiEndPoints.Assets + $"/{id}";
            HttpResponseMessage response = await _httpClient.GetAsync(requestUri).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var res = await response.Content?.ReadAsStringAsync();
            var rootJson = JsonConvert.DeserializeObject<JsonObject<Currency>>(res);
            return rootJson.Data;
        }

    }
}
