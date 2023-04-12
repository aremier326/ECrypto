using Microsoft.Extensions.DependencyInjection;

namespace ECrypto.ViewModels.Base
{
    public class ViewModelLocator
    {
        MainWindowVM mainWindowVM;
        public MainWindowVM MainWindowVM
            => mainWindowVM ??= App.Services.GetRequiredService<MainWindowVM>();
    }
}
