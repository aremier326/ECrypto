using ECrypto.Models;
using ECrypto.Services.Interfaces;
using ECrypto.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Windows.Documents;

namespace ECrypto.ViewModels
{
    public class CurrencyInfoVM : ViewModel
    {
        private readonly IApiService _apiService;

        public Currency Currency { get; set; }

        public List<Market> Markets { get; set; }

        public CurrencyInfoVM(Currency currency)
        {
            _apiService = App.Services.GetRequiredService<IApiService>();
            Currency = _apiService.GetCurrencyAsync(currency.Id).Result;
            Markets = _apiService.GetMarketsAsync(currency.Id).Result;
        }
    }
}
