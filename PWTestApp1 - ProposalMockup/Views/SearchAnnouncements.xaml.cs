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
        public static List<string> announcementList = new List<string>();
        public static List<string> announcementContent = new List<string>();
        public static List<string> announcementSender = new List<string>();

        public SearchAnnouncements()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Task.Run(() => AddAnnouncements());
        }

        public class Announcement
        {
            public string AnnouncementTitle { get; set; }
            public string Content { get; set; }
        }

        private void AddAnnouncements()
        {
            announcementList.Clear();
            announcementContent.Clear();
            announcementSender.Clear();

            announcementList = AboutPage.saAnnouncementList;
            announcementContent = AboutPage.saAnnouncementContent;
            announcementSender = AboutPage.saAnnouncementSender;

            int i = 0;
            foreach(string ann in announcementList)
            {
                AnnouncementsInit.Announcement.Add(new Announcement { AnnouncementTitle = ann, Content = announcementSender[i] + ": " + announcementContent[i] });
                i++;
            }

            ItemsInit();
        }

        public static class AnnouncementsInit
        {
            public static IList<Announcement> Announcement { get; set; }

            static AnnouncementsInit()
            {
                Announcement = new ObservableCollection<Announcement>();
            }
        }

        private void ItemsInit()
        {
            Announcements.ItemsSource = AnnouncementsInit.Announcement;
        }

        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as Announcement;
            await Navigation.PushAsync(new ItemDetailPage(details.AnnouncementTitle, details.Content));
        }
    }
}