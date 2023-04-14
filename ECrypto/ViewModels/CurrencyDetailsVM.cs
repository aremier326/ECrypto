using ECrypto.Models;
using ECrypto.Services;
using ECrypto.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Windows.Documents;

namespace ECrypto.ViewModels
{
    public class CurrencyDetailsVM : ViewModel
    {
        private readonly IApiService _apiService;
        public CurrencyInfoVM CurrencyInfoVM { get; private set; }
        public List<Currency> Currencies { get; set; }

        private Currency _selectedCurrency;
        public Currency SelectedCurrency
        {
            get => _selectedCurrency;
            set
            {
                Set(ref _selectedCurrency, value);
                RefreshSelectedCurrency(_selectedCurrency);
            }
        }

        public CurrencyDetailsVM()
        {
            _apiService = App.Services.GetRequiredService<IApiService>();
            CurrencyInfoVM = new CurrencyInfoVM();
            Currencies = _apiService.GetCurrenciesAsync().Result;
            SelectedCurrency = Currencies[0];
        }

        private void RefreshSelectedCurrency(Currency currency)
        {
            Set(ref currency, _apiService.GetCurrencyAsync(currency.Id).Result);
        }
    }
}
