using ECrypto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECrypto.Services.Interfaces
{
    public interface IApiService
    {
        public Task<List<Currency>> GetCurrenciesAsync(int count = -1);
        public Task<Currency> GetCurrencyAsync(string id);
        public Task<List<Market>> GetMarketsAsync(string id);
    }
}
