using PWTestApp1___ProposalMockup.ViewModels;
using PWTestApp1___ProposalMockup.Views;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PWTestApp1___ProposalMockup
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Navigation.PushAsync(new LoginPage());
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private async void BrowserIEMB(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://iemb.hci.edu.sg/", BrowserLaunchMode.SystemPreferred);
        }
        
        private async void BrowserISP(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://isphs.hci.edu.sg/index.asp", BrowserLaunchMode.SystemPreferred);
        }
        private async void Results(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Results");
        }
    }
}
