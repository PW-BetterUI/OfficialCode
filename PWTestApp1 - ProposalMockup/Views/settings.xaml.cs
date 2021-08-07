﻿using System;
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
        public settings()
        {
            InitializeComponent();
        }

        public bool ThemePreference
        {
            get => Preferences.Get(nameof(ThemePreference), false);
            set
            {
                Preferences.Set(nameof(ThemePreference), value);
                OnPropertyChanged(nameof(ThemePreference));
            }
        }

        private void SavePreferences(object sender, EventArgs e)
        {

        }

        void DarkModeToggled(object sender, ToggledEventArgs e)
        {
            if(e.Value == true)
            {
                Console.WriteLine("DarkMode on");
                Application.Current.UserAppTheme = OSAppTheme.Dark;
            }
            else if (e.Value == false)
            {
                Application.Current.UserAppTheme = OSAppTheme.Light;
            }
        }
    }
}