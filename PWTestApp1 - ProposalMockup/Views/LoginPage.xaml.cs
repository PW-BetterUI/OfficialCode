using PWTestApp1___ProposalMockup.ViewModels;
using PWTestApp1___ProposalMockup.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Diagnostics;
using System.Security.Permissions;
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

        static bool failed = true;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login(System.Object sender, System.EventArgs e)
        {
            CheckEntries(idField.Text, passwordField.Text);
        }

        private void CheckEntries(string id, string pass)
        {
            CheckEntries(idField.Text, passwordField.Text);

            if (failed)
            {
                errorMsg.IsVisible = true;
            }
            else
            {
                errorMsg.IsVisible = false;
            }
        }
        public GoogleCredential credential;
        void checkCredentials()
        {
            string localDir = Directory.GetCurrentDirectory();
            string upastep = Path.GetDirectoryName(@"..\localDir");
            string path = @"..\Data\clientSecrets.json";
            Debug.WriteLine(path);
            //string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "clientSecrets.json");

            try
            {
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    credential = GoogleCredential.FromStream(stream)
                        .CreateScoped(Scopes);
                }
                service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
            }
            catch {
                Console.WriteLine("Could not find file you dumbshit");
            }
               
            
            
            
        }
        void CheckEntries(string id, string pass)
        {
            checkCredentials();
            int i = 0;

            var range = $"{sheet}!A2:D5";
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);

            var response = request.Execute();
            var values = response.Values;
            foreach (var row in values)
            {
                if (pass == row[3].ToString() && failed == false)
                {
                    Console.WriteLine("password correct yes");
                    errorMsg.IsVisible = false;
                    await Shell.Current.GoToAsync("//AboutPage");
                    return;
                }
                else if (failed || pass == null)
                {
                    Console.WriteLine("bruh password incorrect");
                    errorMsg.IsVisible = true;
                    return;
                }
            }
        }

        private void CheckUserID(string id)
        {
            CheckCredentials();
            int i = 0;

            var range = $"{sheet}!A2:D5";
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);

            var response = request.Execute();
            var values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (id.ToLower() == row[0].ToString())
                    {
                        Console.WriteLine("yes");
                        errorMsg.IsVisible = false;
                        failed = false;
                        return;
                    }
                    else if ((i == 3 && id != row[0].ToString()) || id == null)
                    {
                        Console.WriteLine("no");
                        errorMsg.IsVisible = true;
                        return;
                    }
                    i++;
                }
            }
        }
    }
}