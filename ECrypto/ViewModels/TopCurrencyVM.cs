using ECrypto.Commands;
using ECrypto.Models;
using ECrypto.Services;
using ECrypto.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ECrypto.ViewModels
{
    public class TopCurrencyVM : ViewModel
    {
        private readonly IApiService _apiService;
        public ObservableCollection<Currency> Currencies { get; set; }

        public TopCurrencyVM()
        {
            _apiService = App.Services.GetRequiredService<IApiService>();

            Currencies = new ObservableCollection<Currency>(_apiService.GetCurrenciesAsync(10).Result);
        }

        private ICommand refreshCommand;
        public ICommand RefreshCommand
            => refreshCommand ??= new RelayCommand(OnRefreshExecuted, CanRefreshExecute);
        
        private void OnRefreshExecuted(object o)
        {
            Currencies = new ObservableCollection<Currency>(_apiService.GetCurrenciesAsync(10).Result);
        }

        private bool CanRefreshExecute(object o) => true;
    }
}
