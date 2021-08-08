using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Mobile.Forms;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace PWTestApp1___ProposalMockup.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class safeEntry : ContentPage
    {
        public safeEntry()
        {
            InitializeComponent();
            var status = Permissions.RequestAsync<Permissions.Camera>();
            DisplayAlert("Alert", "If QR Scanner shows white: \nGo to Settings and enable Camera for this app\nRelaunch the app", "OK");
        }

        public int Result;
        private async void Scan(object sender, EventArgs e)
        {
            var scan = new ZXingScannerPage();
            await Navigation.PushAsync(scan);
            scan.OnScanResult += (result) =>
              {
                  Device.BeginInvokeOnMainThread(async () =>
                  {
                      await Navigation.PopAsync();
                      area.Text = result.Text;
                      CheckIn();
                      Console.WriteLine("Working");
                  });
              };
        }

        public void CheckIn()
        {
            scan.IsVisible = false;
            DisplayAlert("SafeEntry", "You have checked in", "OK");
            checkOut.IsVisible = true;

        }

        private void CheckOut(object sender, EventArgs e)
        {

            checkOut.IsVisible = false;
            DisplayAlert("SafeEntry", "You have checked out", "OK");
            scan.IsVisible = true;
            area.Text = "Scanned Data will Appear Here";
        }
    }
}