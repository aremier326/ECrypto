using ECrypto.Models;
using ECrypto.Services.ApiEndpoints;
using ECrypto.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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
            string requestUri = ApiEndPoints.GetAsset(id);
            HttpResponseMessage response = await _httpClient.GetAsync(requestUri).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var res = await response.Content?.ReadAsStringAsync();
            var rootJson = JsonConvert.DeserializeObject<JsonObject<Currency>>(res);
            return rootJson.Data;
        }

        public async Task<List<Market>> GetMarketsAsync(string id)
        {
            string requestUri = ApiEndPoints.GetMarkets(id);
            HttpResponseMessage response = await _httpClient.GetAsync(requestUri).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var res = await response.Content.ReadAsStringAsync();
            var rootJson = JsonConvert.DeserializeObject<JsonArray<Market>>(res);
            return rootJson.Data;
        }

    }
}
