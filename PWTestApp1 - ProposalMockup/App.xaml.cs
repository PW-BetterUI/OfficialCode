using PWTestApp1___ProposalMockup.Services;
using PWTestApp1___ProposalMockup.Views;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PWTestApp1___ProposalMockup.ViewModels;

namespace PWTestApp1___ProposalMockup
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();

            Device.SetFlags(new string[] { "AppTheme_Experimental" });
        }

        protected override void OnStart()
        {
            string AppPref = Preferences.Get("SystemThemePreference", "Default");
            if(AppPref == "Dark")
            {
                Application.Current.UserAppTheme = OSAppTheme.Dark;
            }
            else if(AppPref == "Light")
            {
                Application.Current.UserAppTheme = OSAppTheme.Light;
            }
            else if(AppPref == "Default")
            {
                Application.Current.UserAppTheme = Application.Current.RequestedTheme; 
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
