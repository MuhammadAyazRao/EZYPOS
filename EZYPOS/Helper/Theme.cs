using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EZYPOS.Helper
{
    class Theme
    {

        public ResourceDictionary ThemeDictionary
        {
            // You could probably get it via its name with some query logic as well.
            get { return Application.Current.Resources.MergedDictionaries[0]; }
        }

        public void ChangeTheme(Uri uri)
        {
            ThemeDictionary.MergedDictionaries.Clear();
            ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
        }
        
        public void CreateandChangeTheme(IBaseTheme Base, System.Windows.Media.Color Primary, System.Windows.Media.Color Acent)
        {
            var data = Application.Current.Resources.GetTheme();
            var the = MaterialDesignThemes.Wpf.Theme.Create(MaterialDesignThemes.Wpf.Theme.Dark, MaterialDesignColors.Recommended.AmberSwatch.Amber100, MaterialDesignColors.Recommended.AmberSwatch.Amber100);
            // var themesa = MaterialDesignColors.Recommended.YellowSwatch;
            var the2 = Application.Current.TryFindResource("LightBlue.xaml");
            Application.Current.Resources.SetTheme(the);
        }


        public virtual ITheme GetTheme()
        {
            if (Application.Current is null)
                throw new InvalidOperationException("Cannot get theme outside of a WPF application. Use ResourceDictionaryExtensions.GetTheme on the appropriate resource dictionary instead.");
            return Application.Current.Resources.GetTheme();
        }

        public virtual void SetTheme(ITheme theme)
        {

            if (theme is null) throw new ArgumentNullException(nameof(theme));
            if (Application.Current is null)
                throw new InvalidOperationException("Cannot set theme outside of a WPF application. Use ResourceDictionaryExtensions.SetTheme on the appropriate resource dictionary instead.");
            Application.Current.Resources.SetTheme(theme);
        }

        public virtual IThemeManager GetThemeManager()
        {
            if (Application.Current is null)
                throw new InvalidOperationException("Cannot get ThemeManager. Use ResourceDictionaryExtensions.GetThemeManager on the appropriate resource dictionary instead.");
            return Application.Current.Resources.GetThemeManager();
        }
    }
}
