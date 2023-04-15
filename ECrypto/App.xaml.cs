using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ECrypto.Services;
using ECrypto.ViewModels.Base;
using ECrypto.Services.Interfaces;

namespace ECrypto
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IHost _host;
        public static IHost Host => _host ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
        public static IServiceProvider Services => _host.Services;

        public static IHostBuilder CreateHostBuilder(string[] args)
            => Microsoft.Extensions.Hosting.Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(ConfigureServices);

        internal static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
            => services
            .AddViewModels()
            .AddServices();

        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;
            base.OnStartup(e);
            await host.StartAsync();
            using (var scope = Services.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<IThemeService>().InitTheme();
            }
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            var host = Host;
            base.OnExit(e);
            await host.StopAsync();
        }
    }
}
