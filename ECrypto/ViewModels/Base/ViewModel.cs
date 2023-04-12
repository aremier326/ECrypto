using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ECrypto.ViewModels.Base
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if(Equals(value, field)) return true;
            field = value;
            OnPropertyChanged(propertyName);
            return false;
        }
    }
}
