using PWTestApp1___ProposalMockup.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using Google.Apis.Sheets.v4;
using Google.Apis.Auth.OAuth2;
using Xamarin.Essentials;
using System.Collections.Generic;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Linq;

namespace PWTestApp1___ProposalMockup.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static readonly string ApplicationName = "Test";
        static readonly string SpreadsheetId = "1w7bPa_hrH382oVPDwIW9EotY-rzHcj8VHBesYPHPNEg";
        static readonly string studentInformationSheet = "Student Information";
        static readonly string announcementLogSheet = "Announcement Log";
        static SheetsService service;

        public static int idPos = AboutPage.idPosition; //outputs 0?
        public static int announcementId = new int();
        public static string userID;

        public ItemDetailPage(string Title, string Content)
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();

            AnnouncementTitle.Text = Title;
            AnnouncementContent.Text = Content;

            //announcementId = AnnouncementID;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();



            await Task.Delay(5000);
            await Task.Run(() => ReadAnnouncement(AnnouncementTitle.Text));
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

        public void ReadAnnouncement(string title)
        {
            CredentialsInit();
            Console.WriteLine("Test");
            Console.WriteLine("title= " + title);

            var range = $"{announcementLogSheet}!A1:A";
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);

            var response = request.Execute();
            var values = response.Values;

            int id = 0;

            foreach (var row in values)
            {
                if (row[0].ToString() == title)
                {
                    announcementId = id;
                    Console.WriteLine("found it");
                    ReplaceAnnouncement(announcementId);
                    break;
                }
                else
                {
                    id++;
                    Console.WriteLine("tryagain");
                }
            }

        }

        public void ReplaceAnnouncement(int id)
        {
            CredentialsInit();

            var range = $"{studentInformationSheet}!A1:N";
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);

            var response = request.Execute();
            var values = response.Values;

            List<string> idnum = new List<string>();
            string sendBack;
            
            foreach (var row in values)
            {
                string ids = row[11].ToString();
                if (ids == "0")
                {
                    break;
                }
                if (ids == "UnreadAnnouncements")
                {

                }
                else
                {
                    if (ids.Contains(","))
                    {
                        ids = ids.Replace(',', ' ');
                        idnum = ids.Split(' ').ToList();
                    }
                    else
                    {
                        idnum.Add(ids);
                    }

                    foreach (var i in idnum)
                    {
                        Console.WriteLine(i); //remember to remove
                    }

                    foreach (var i in idnum)
                    {
                        if (i == id.ToString())
                        {
                            idnum.Remove(i);
                            break;
                        }
                        else
                        {

                        }
                    }

                    sendBack = string.Join(",", idnum);
                    Console.WriteLine(sendBack);

                    int rowno = 1;


                    //Console.WriteLine(userID);
                    //foreach (var i in values)
                    //{
                    //    if (userID != row[0].ToString())
                    //    {
                    //        rowno++;
                    //    }
                    //}
                        
                    range = $"{studentInformationSheet}!M"+idPos; //find value of idpos
                    var ValueRange = new ValueRange();

                    var objectList = new List<object>() { sendBack };
                    ValueRange.Values = new List<IList<object>> { objectList };

                    var updateRequest = service.Spreadsheets.Values.Update(ValueRange, SpreadsheetId, range);
                    updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                    var updateResponse = updateRequest.Execute();

                    Console.WriteLine("nice");
                }
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