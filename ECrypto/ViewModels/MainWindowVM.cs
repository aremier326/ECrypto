using ECrypto.Commands;
using ECrypto.ViewModels.Base;
using System.Windows.Input;

namespace ECrypto.ViewModels
{
    public class MainWindowVM : ViewModel
    {
        public string Title { get; set; } = "ECrypto";


        private ViewModel curVm;

        public ViewModel CurrentVm
        {
            get { return curVm; }
            private set { Set(ref curVm, value); }
        }

        public MainWindowVM()
        {
            CurrentVm = new TopCurrencyVM();
        }


        #region ShowTopCommand

        private ICommand showTopCommand;
        public ICommand ShowTopCommand
            => showTopCommand ??= new RelayCommand(OnShowTopExecuted, CanShowTopExecute);

        private void OnShowTopExecuted(object o)
        {
            if (CurrentVm.GetType() == typeof(TopCurrencyVM)) return;
            CurrentVm = new TopCurrencyVM();
        }

        private bool CanShowTopExecute(object o)
            => CurrentVm.GetType() != typeof(TopCurrencyVM);

        #endregion

        #region ShowDetailCommand

        private ICommand showdetailCommand;
        public ICommand ShowDetailCommand => showdetailCommand ??= new RelayCommand(OnShowDetailExecuted, CanShowDetailExetute);

        private void OnShowDetailExecuted(object o)
        {
            if (CurrentVm.GetType() == typeof(CurrencyDetailsVM)) return;
            CurrentVm = new CurrencyDetailsVM();
        }
        private bool CanShowDetailExetute(object o)
            => CurrentVm.GetType() != typeof(CurrencyDetailsVM);

        #endregion
    }
}
