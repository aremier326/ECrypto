using ECrypto.Models;
using ECrypto.Services.Interfaces;
using ECrypto.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace ECrypto.ViewModels
{
    public class CurrencyDetailsVM : ViewModel
    {
        private readonly IApiService _apiService;
        private List<Currency> _currencies;
        public CurrencyInfoVM InfoVM { get; set; }

        private List<Currency> _filteredCurrencies;
        public List<Currency> FilteredCurrencies
        {
            get => _currencies;
            set
            {
                Set(ref _filteredCurrencies, value);
                SelectedCurrency = _filteredCurrencies.FirstOrDefault();
            }
        }

        private Currency _selectedCurrency;
        public Currency SelectedCurrency
        {
            get => _selectedCurrency;
            set
            {
                Set(ref _selectedCurrency, value);
                if (value == null)
                {
                    InfoVM = null;
                    return;
                }
                InfoVM = new CurrencyInfoVM(value);
            }
        }

        private string _searchCriteria = string.Empty;
        public string SearchCriteria
        {
            get => _searchCriteria;
            set
            {
                Set(ref _searchCriteria, value);
                if (FilterChanged != null) FilterChanged();
            }
        }

        public CurrencyDetailsVM()
        {
            _apiService = App.Services.GetRequiredService<IApiService>();
            _currencies = _apiService.GetCurrenciesAsync().Result;
            FilterChanged += OnFilterChanged;
            if (FilterChanged != null) FilterChanged();
        }

        private void RefreshSelectedCurrency(ref Currency currency)
        {
            if(currency == null) return;
            currency = _apiService.GetCurrencyAsync(currency.Id).Result;
        }

        private void OnFilterChanged()
        {
            if (SearchCriteria == string.Empty)
            {
                FilteredCurrencies = _currencies;
                return;
            }
            FilteredCurrencies = _currencies.Where(x => x.Name.ToLower().Contains(SearchCriteria.ToLower())
                || x.Symbol.ToLower().Contains(SearchCriteria.ToLower())).ToList();
        }

        private delegate void FilterChangedHandler();
        private FilterChangedHandler FilterChanged;

    }
}
