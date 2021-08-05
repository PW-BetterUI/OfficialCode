using System;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
// !!!!!!!!!!!!!!!!!!! WARNING: REMEBER TO FIND A WAY TO GET RID OF client_secrets.json WHEN LAUNCHING FINAL PROJECT; SYSTEM CAN BE HACKED!!!!!!!!!!!!!!!!!!!

namespace PWTestApp1___ProposalMockup.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class LoginPage : ContentPage
    {
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static readonly string ApplicationName = "Test";
        static readonly string SpreadsheetId = "1w7bPa_hrH382oVPDwIW9EotY-rzHcj8VHBesYPHPNEg";
        static readonly string sheet = "Student Information";
        static SheetsService service;

        private static bool idFailed = true;
        private static bool passwordFailed = true;

        private static int idPos = 0;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login(System.Object sender, System.EventArgs e)
        {
            CheckEntries(idField.Text, passwordField.Text);
        }

        public async void CheckEntries(string id, string pass)
        {
            activityIndicator.IsRunning = true;
            errorMsg.IsVisible = false;

            await Task.Run(() =>
            {
                CheckUserID(id);
                CheckPassword(pass);
            });

            if (idFailed || passwordFailed)
            {
                errorMsg.IsVisible = true;
            }
            else
            {
                await Shell.Current.GoToAsync("//AboutPage");

                errorMsg.IsVisible = false;
                AboutPage.idPosition = idPos;
            }

            idFailed = true;
            passwordFailed = true;
            activityIndicator.IsRunning = false;

            idPos = 0;
        }

        private async void CheckCredentials()
        {
            GoogleCredential credential;

            credential = GoogleCredential.FromStream(await FileSystem.OpenAppPackageFileAsync("clientSecrets.json"))
                .CreateScoped(Scopes);

            service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }
        private void CheckUserID(string id)
        {
            CheckCredentials();

            var range = $"{sheet}!A2:D";
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);

            var response = request.Execute();
            var values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (id != null && id.ToLower() == row[0].ToString())
                    {
                        Console.WriteLine("yes");
                        idFailed = false;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("no");
                    }
                    idPos++;
                }
            }
        }

        private void CheckPassword(string pass)
        {
            CheckCredentials();

            int i = 0;

            var range = $"{sheet}!A2:D5";
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);

            var response = request.Execute();
            var values = response.Values;
            foreach (var row in values)
            {
                if (pass == row[3].ToString() && !idFailed && pass != null && i == idPos)
                {
                    Console.WriteLine("password correct yes");
                    passwordFailed = false;
                    return;
                }
                else //if (failed || pass == null)
                {
                    Console.WriteLine("bruh password incorrect");
                }
                i++;
            }
        }
    }
}