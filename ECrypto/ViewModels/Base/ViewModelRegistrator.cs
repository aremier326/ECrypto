using Microsoft.Extensions.DependencyInjection;

namespace ECrypto.ViewModels.Base
{
    public static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
            => services.AddTransient<MainWindowVM>();
    }
}
