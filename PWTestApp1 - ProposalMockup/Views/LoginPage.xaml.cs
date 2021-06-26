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
        
        static string resp;

        static int pos = 0;
        static int i = 0;
        static int x = 0;

        static bool failed = false;
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
        void login(System.Object sender, System.EventArgs e)
        {
            checkCredentials(idField.Text, passwordField.Text, 1);
            if (failed)
            {
                errorMsg.IsVisible = true;
                failed = false;
            }
            else
            {
                errorMsg.IsVisible = false;
                failed = true;
            }
        }
        static void checkCredentials(string id, string pw, int _case)
        {
            GoogleCredential credential;

            //string path = Path.Combine(Directory.GetCurrentDirectory(), "\\clientSecrets.json");
            //string path = new FileInfo("test.txt").Directory.FullName;
            //string path = Path.GetFullPath("test.txt");
            //string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "clientSecrets.json");
            ////Console.WriteLine(path);


            //using (var stream = new FileStream(@"C:\Sun Zizhuo\Code\C#\WPF, XAML\PWTestApp1 - ProposalMockup\PWTestApp1 - ProposalMockup\Data\clientSecrets.json", FileMode.Open, FileAccess.Read))
            //{
            //    credential = GoogleCredential.FromStream(stream)
            //        .CreateScoped(Scopes);
            //    Console.WriteLine("eeeeeeeeeeeeeee");
            //}

            //service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
            //{
            //    HttpClientInitializer = credential,
            //    ApplicationName = ApplicationName,
            //});

            //ReadEntries(_case, id);
        }
        static void ReadEntries(int _case, string resp)
        {
            var range = $"{sheet}!A2:D5";
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);

            var response = request.Execute();
            var values = response.Values;
            if(values != null && values.Count > 0)
            {
                switch (_case)
                {
                    case 1:
                        foreach (var row in values)
                        {
                            if (resp == row[0].ToString())
                            {
                                Console.WriteLine("User found! Retrieving their information...");
                                pos = i;
                                return;
                            }
                            else if (i == 3)
                            {
                                Console.WriteLine("User not found! Are you sure you have not entered the wrong information?");
                                failed = true;
                                return;
                            }
                            i++;
                        }
                    break;
                }
            }
        }
    }
}