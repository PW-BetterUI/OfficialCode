using System;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;

namespace PWTestApp1___ProposalMockup.Views
{
    public partial class AboutPage : ContentPage
    {
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static readonly string ApplicationName = "Test";
        static readonly string SpreadsheetId = "1w7bPa_hrH382oVPDwIW9EotY-rzHcj8VHBesYPHPNEg";
        static readonly string sheet = "Student Information";
        static SheetsService service;

        public AboutPage()
        {
            StackLayout stackLayout = Announcements;
            InitializeComponent();
        }

        public void countButton(System.Object sender, System.EventArgs e)
        {

        }

        private async void GetAnnouncementInformation()
        {
            GoogleCredential credential;

            credential = GoogleCredential.FromStream(await FileSystem.OpenAppPackageFileAsync("client_secrets.json"))
                .CreateScoped(Scopes);

            service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        private void buttontoinsertmoreannouncementsthisisthelongestnameever_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Its working i think");
            Announcements.Children.Clear();
            int x = Convert.ToInt32(buttonNum.Text);
            while (x > 0)
            {
                Announcements.Children.Add(new Button { Text = "Announcement" });
                x--;
            }
        }
    }
}