using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PWTestApp1___ProposalMockup.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchAnnouncements : ContentPage
    {
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static readonly string ApplicationName = "Test";
        static readonly string SpreadsheetId = "1w7bPa_hrH382oVPDwIW9EotY-rzHcj8VHBesYPHPNEg";
        static readonly string studentInformationSheet = "Student Information";
        static readonly string announcementLogSheet = "Announcement Log";
        static SheetsService service;

        public SearchAnnouncements()
        {
            InitializeComponent();
        }

        public class Announcement
        {
            public string AnnouncementTitle { get; set; }
            public string Content { get; set; }
        }

        private async void GetAnnouncements()
        {
            GoogleCredential credential;

            credential = GoogleCredential.FromStream(await FileSystem.OpenAppPackageFileAsync("clientSecrets.json"))
                .CreateScoped(Scopes);

            service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            var range = $"{studentInformationSheet}!L2:N";
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);

            var response = request.Execute();
            var values = response.Values;

            List<string> assignedAnnouncemetIds = new List<string>();

            foreach(var row in values)
            {
                string ids = row[13].ToString();

                ids = ids.Replace(',', ' ');
                assignedAnnouncemetIds = ids.Split(' ').ToList();
            }

            var range_ = $"{announcementLogSheet}!A2:K";
            var request_ = service.Spreadsheets.Values.Get(SpreadsheetId, range);

            var response_ = request.Execute();
            var values_ = response.Values;

            foreach(string id in assignedAnnouncemetIds)
            {
                foreach(var row_ in values_)
                {

                }
            }
        }

        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as Announcement;
            await Navigation.PushAsync(new ItemDetailPage(details.AnnouncementTitle, details.Content));
        }
    }
}