using System;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
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
        static readonly string studentInformationSheet = "Student Information";
        static readonly string announcementLogSheet = "Announcement Log";
        static SheetsService service;

        public static string announcements;
        public static bool announcementExist = false;
        public static List<string> announcementList = new List<string>();

        public static int idPosition;

        public AboutPage()
        {
            StackLayout stackLayout = Announcements;
            InitializeComponent();
        }

        public void countButton(System.Object sender, System.EventArgs e)
        {

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

            List<string> unreadAnnouncementIds = new List<string>();

            int i = 0;
            if (/*values != null && */values.Count > 0)
            {
                foreach(var row in values)
                {
                    if(i == idPosition)
                    {
                        string ids = row[0].ToString();
                        if(ids == "0")
                        {
                            break;
                        }
                        else
                        {
                            announcementExist = true;

                            if (ids.Contains(','))
                            {
                                ids = ids.Replace(',', ' ');
                                unreadAnnouncementIds = ids.Split(' ').ToList();
                            }
                            else
                            {
                                unreadAnnouncementIds.Add(ids);
                            }

                            var range_ = $"{announcementLogSheet}!A2:K";
                            var request_ = service.Spreadsheets.Values.Get(SpreadsheetId, range_);

                            var response_ = request_.Execute();
                            var values_ = response_.Values;

                            foreach (var row_ in values_)
                            {
                                if (unreadAnnouncementIds.Contains(row_[10].ToString()))
                                {
                                    announcementList.Add(row_[0].ToString());
                                }
                            }

                            //foreach (string s in unreadAnnouncementIds)
                            //{
                            //    foreach (var row_ in values_)
                            //    {
                            //        if (s == row_[10].ToString())
                            //        {
                            //            announcementList.Add(row[0].ToString());
                            //        }
                            //    }
                            //}
                        }
                    }
                    i++;
                }
            }

            //announcements = buttonNum.Text;
        }

        private async void Buttontoinsertmoreannouncementsthisisthelongestnameever_Clicked(object sender, EventArgs e)
        {   
            announcementList.Clear();
            Announcements.Children.Clear();
            buttontoinsertmoreannouncementsthisisthelongestnameever.IsEnabled = false;

            await Task.Run(() => GetAnnouncements());

            //announcements = buttonNum.Text;
            //announcementList.Add(announcements);
            if (!announcementExist)
            {
                Announcements.Children.Add(new Label { Text = "No announcements yet. Yay!", TextColor = Color.Black, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center });
            }
            else
            {
                int i = announcementList.Count();
                for (int d = 0; d < i; d++)
                {
                    Console.WriteLine(announcementList[d]);
                    Announcements.Children.Add(new Button { Text = announcementList[d] });
                }
            }

            //Console.WriteLine("Its working i think");
            //Announcements.Children.Clear();
            //int x = Convert.ToInt32(buttonNum.Text);
            //while (x > 0)
            //{
            //    Announcements.Children.Add(new Button { Text = "Announcement" });
            //    x--;
            //}
        }
    }
}