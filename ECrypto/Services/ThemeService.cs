using ECrypto.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ECrypto.Services
{
    public class ThemeService : IThemeService
    {
        private readonly Uri darkTheme = new Uri("Resources/Styles/Brushes/DarkThemeBrushes.xaml", UriKind.RelativeOrAbsolute);

        private readonly Uri lightTheme = new Uri("Resources/Styles/Brushes/LightThemeBrushes.xaml", UriKind.RelativeOrAbsolute);

        private ResourceDictionary ThemeDictionary => App.Current.Resources.MergedDictionaries[0];

        public void ChangeTheme()
        {
            if (ThemeDictionary.Source == lightTheme)
            {
                ThemeDictionary.Source = darkTheme;
                return;
            }
            ThemeDictionary.Source = lightTheme;
        }
        public void InitTheme()
        {
            ThemeDictionary.Source = lightTheme;
        }
    }
}
