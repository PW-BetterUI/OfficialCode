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

        static bool failed = false;

        const string fileName = "clientSecrets.json";

        public LoginPage()
        {
            Debug.WriteLine("Testing");
            String relPath = GetRelativePath(@"C:\Users\OSdoge\source\repos\BetterUI\PWTestApp1 - ProposalMockup\Data\clientSecrets.json", @"C:\Users\OSdoge\source\repos\BetterUI\PWTestApp1 - ProposalMockup\Views");
            Debug.WriteLine(relPath);
            this.BindingContext = new LoginViewModel();
            InitializeComponent(); 
            //..\Data\clientSecrets.json
        }
        
        public static string GetRelativePath(string fullPath, string basePath)
        {
            if (!basePath.EndsWith("\\"))
                basePath += "\\";

            Uri baseUri = new Uri(basePath);
            Uri fullUri = new Uri(fullPath);

            Uri relativeUri = baseUri.MakeRelativeUri(fullUri);

            return relativeUri.ToString().Replace("/", "\\");
        }

        void login(System.Object sender, System.EventArgs e)
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
            if(values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (id == row[0].ToString())
                    {
                        Console.WriteLine("User ID check is complete and matches with data in database!");
                        return;
                    }
                    else if (i == 3)
                    {
                        failed = true;
                        return;
                    }
                }
                foreach (var row in values)
                {
                    if (id == row[3].ToString())
                    {
                        Console.WriteLine("Password check is complete and matches with data in databse!");
                        return;
                    }
                    else if (i == 3)
                    {
                        failed = true;
                        return;
                    }
                }
            }
        }
    }
}