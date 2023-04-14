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
            string requestUri = ApiEndPoints.CoinMarkets + "?vs_currency=usd";

            HttpResponseMessage response = await _httpClient.GetAsync(requestUri).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var res = await response.Content.ReadAsStringAsync();

            var currencies = JsonConvert.DeserializeObject<List<Currency>>(res);

            if (count > 0) currencies = currencies.GetRange(0, count);

            return currencies;
        }

    }
}
