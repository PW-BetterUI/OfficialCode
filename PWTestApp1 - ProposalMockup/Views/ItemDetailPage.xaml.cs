using PWTestApp1___ProposalMockup.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace PWTestApp1___ProposalMockup.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static readonly string ApplicationName = "Test";
        static readonly string SpreadsheetId = "1w7bPa_hrH382oVPDwIW9EotY-rzHcj8VHBesYPHPNEg";
        static readonly string studentInformationSheet = "Student Information";
        static SheetsService service;

        public static int idPos = new int();
        public static int announcementId = new int();

        public ItemDetailPage(string Title, string Content)
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();

            AnnouncementTitle.Text = titleName;
            AnnouncementContent.Text = Content;

            //announcementId = AnnouncementID;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Task.Delay(5000);
            await Task.Run(() => ReadAnnouncement(announcementId));
        }

        private void ToolbarItem_Clicked(object sender, System.EventArgs e)
        {

        }

        private async void CredentialsInit()
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

        public void ReadAnnouncement(int id)
        {
            CredentialsInit();

            var range = $"{studentInformationSheet}!A:M";
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);

            var response = request.Execute();
            var values = response.Values;

            int i = 0;
            foreach(var row in values)
            {
                if(i == idPos)
                {
                    string currentIds = "";
                    string newIds = "";

                    if (row[12].ToString() != null)
                    {
                        currentIds = row[12].ToString();
                        newIds = currentIds + $",{id}";
                    }
                    else
                    {
                        newIds = id.ToString();
                    }

                    var range_ = $"{studentInformationSheet}!M{i}";
                    var valueRange = new ValueRange();

                    var objectList = new List<object>() { newIds };
                    valueRange.Values = new List<IList<object>> { objectList };

                    var updateRequest = service.Spreadsheets.Values.Update(valueRange, SpreadsheetId, range_);
                    updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                    var updateResponse = updateRequest.Execute();
                }

                i++;
            }
        }

                
                
                
                //if(i == idPos)
                //{
                //    string currentIds = "";
                //    string newIds = "";

                //    if (row[12].ToString() != null)
                //    {
                //        currentIds = row[12].ToString();
                //        newIds = currentIds + $",{id}";
                //    }
                //    else
                //    {
                //        newIds = id.ToString();
                //    }

                //    var range_ = $"{studentInformationSheet}!M{i}";
                //    var valueRange = new ValueRange();

                //    var objectList = new List<object>() { newIds };
                //    valueRange.Values = new List<IList<object>> { objectList };

                //    var updateRequest = service.Spreadsheets.Values.Update(valueRange, SpreadsheetId, range_);
                //    updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                //    var updateResponse = updateRequest.Execute();
                //}

                //i++;
            
        
    }
}