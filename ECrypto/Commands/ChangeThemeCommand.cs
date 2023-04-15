using ECrypto.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ECrypto.Commands
{
    class ChangeThemeCommand : Command
    {
        public override bool CanExecute(object? parameter)
            => true;

        public override void Execute(object? parameter)
        {
            App.Services.GetRequiredService<IThemeService>().ChangeTheme();
        }
    }
}
