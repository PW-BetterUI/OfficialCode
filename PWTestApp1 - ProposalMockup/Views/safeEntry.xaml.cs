using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Mobile.Forms;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace PWTestApp1___ProposalMockup.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class safeEntry : ContentPage
    {
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static readonly string ApplicationName = "Test";
        static readonly string SpreadsheetId = "1w7bPa_hrH382oVPDwIW9EotY-rzHcj8VHBesYPHPNEg";
        static readonly string safeEntryLog = "SafeEntry Log";
        static SheetsService service;

        public safeEntry()
        {
            InitializeComponent();
            var status = Permissions.RequestAsync<Permissions.Camera>();
            DisplayAlert("Alert", "If QR Scanner shows white: \n \nGo to Settings and enable Camera for this app\n \nRelaunch the app", "OK");
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

                      bool isNumeric = int.TryParse(result.Text, out _);

                      if (isNumeric)
                      {
                          switch (int.Parse(result.Text))
                          {
                              case 1:
                                  var range = $"SafeEntry Log!A2:D2";
                                  var valueRange = new ValueRange();

                                  var objectList = new List<object>() { "211530w", "Sun Zizhuo", "1O3", "123456789" };
                                  valueRange.Values = new List<IList<object>> { objectList };

                                  var appendRequest = service.Spreadsheets.Values.Append(valueRange, SpreadsheetId, range);
                                  appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                                  var appendReponse = appendRequest.Execute();

                                  CheckIn("Kong Chian Library");

                                  break;
                          }
                      }
                      else
                      {
                          await DisplayAlert("Alert", "QR Code is not valid, please try again.", "OK");
                      }

                      area.Text = result.Text;
                      Console.WriteLine("Working");
                  });
              };
        }

        public void CheckIn(string location)
        {
            scan.IsVisible = false;
            DisplayAlert("SafeEntry", "You have checked in to {0}", location, "OK");
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