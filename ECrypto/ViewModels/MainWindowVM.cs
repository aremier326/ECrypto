using ECrypto.Models;
using ECrypto.Commands;
using ECrypto.Services;
using ECrypto.ViewModels.Base;
using System.Collections.Generic;
using System.Windows.Input;

namespace ECrypto.ViewModels
{
    public class MainWindowVM : ViewModel
    {
        private TopCurrencyVM topCurrencyVM;
        private CurrencyDetailsVM currencyDetailsVM;
        private ViewModel curVm;

        public ViewModel CurrentVm
        {
            get { return curVm; }
            private set { Set(ref curVm, value); }
        }

        public MainWindowVM()
        {
            topCurrencyVM = new TopCurrencyVM();
            currencyDetailsVM = new CurrencyDetailsVM();
            CurrentVm = topCurrencyVM;
        }


        #region ShowTopCommand

        private ICommand showTopCommand;
        public ICommand ShowTopCommand
            => showTopCommand ??= new RelayCommand(OnShowTopExecuted, CanShowTopExecute);
        
        private void OnShowTopExecuted(object o)
        {
            if (CurrentVm == topCurrencyVM) return;
            CurrentVm = topCurrencyVM;
        }

        private bool CanShowTopExecute(object o)
            => CurrentVm != topCurrencyVM;

        #endregion

        #region ShowDetailCommand

        private ICommand showdetailCommand;
        public ICommand ShowDetailCommand => showdetailCommand ??= new RelayCommand(OnShowDetailExecuted, CanShowDetailExetute);

        private void OnShowDetailExecuted(object o)
        {
            if (CurrentVm == currencyDetailsVM) return;
            CurrentVm = currencyDetailsVM;
        }
        private bool CanShowDetailExetute(object o) => CurrentVm != currencyDetailsVM;

        #endregion
    }
}
