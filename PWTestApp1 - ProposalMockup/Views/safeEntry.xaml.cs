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
        private async void Button_Pressed(object sender, EventArgs e)
        {
            var scan = new ZXingScannerPage();
            await Navigation.PushAsync(scan);
            scan.OnScanResult += (result) =>
              {
                  Device.BeginInvokeOnMainThread(async () =>
                  {
                      _ = await Navigation.PopAsync();
                      Result = Convert.ToInt32(result);
                  });
              };

            await DisplayAlert("Alert", "Testing", "OK");

            if (Result == 0)
            {
                area.Text = "Scanned Data will Appear Here";
                Console.WriteLine("000!!!Wooooo Zizhuo </3 Siting");
            }
            else
            {
                await DisplayAlert("SafeEntry", "Cheked into Area " + Convert.ToString(Result), "OK");
            }
        }
    }
}