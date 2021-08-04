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
        public static string announcements;
        public static List<string> announcementList = new List<string>();
        public AboutPage()
        {
            StackLayout stackLayout = Announcements;
            InitializeComponent();
        }

        public void countButton(System.Object sender, System.EventArgs e)
        {


            //int c = int.Parse(buttonNum.Text);
            //for(int i = 0; i <= c; i++)
            //{
            //    Console.WriteLine(i);
            //}
            //StackLayout parent;
            //try
            //{
            //    int count = Convert.ToInt32(buttonNum.Text);

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
            announcements = buttonNum.Text;
            announcementList.Add(announcements);
            int i = announcementList.Count();
            Announcements.Children.Clear();
            for (int d = 0; d < i; d++)
            {
                Console.WriteLine(announcementList[d]);
                Announcements.Children.Add(new Button { Text = announcementList[d] });
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