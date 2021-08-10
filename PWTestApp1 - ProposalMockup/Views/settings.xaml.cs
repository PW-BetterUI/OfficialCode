using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PWTestApp1___ProposalMockup.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class settings : ContentPage
    {
        public static string preferences = "System Preferences";

        public settings()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            string AppPref = Preferences.Get("SystemThemePreference", "Dark");
            if (AppPref == "Dark")
            {
                PreferenceSwitch.IsToggled = true;
            }
            else if (AppPref == "Light")
            {
                PreferenceSwitch.IsToggled = false;
            }

            if(Application.Current.UserAppTheme == OSAppTheme.Dark && AppPref != "Light")
            {
                PreferenceSwitch.IsToggled = true;
            }
        }

        void DarkModeToggled(object sender, ToggledEventArgs e)
        {
            if(e.Value)
            {
                Console.WriteLine("DarkMode on");
                Application.Current.UserAppTheme = OSAppTheme.Dark;
                Preferences.Set("SystemThemePreference", "Dark");
                //DisplayAlert("Alert", "Working", "Nice"); //Create DisplayAlert to check the problem with Zizhuo not getting Light Mode
            }
            else if (!e.Value)
            {
                Application.Current.UserAppTheme = OSAppTheme.Light;
                Preferences.Set("SystemThemePreference", "Light");
                //DisplayAlert("Alert", "Working", "Nice"); //Create DisplayAlert to check the problem with Zizhuo not getting Light Mode
            }
        }
    }
}