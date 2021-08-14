using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using PWTestApp1___ProposalMockup.Models;
using PWTestApp1___ProposalMockup.ViewModels;
using PWTestApp1___ProposalMockup.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PWTestApp1___ProposalMockup.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public static List<string> announcementList = new List<string>();
        public static List<string> announcementSender = new List<string>();
        public static List<string> announcementContent = new List<string>();
        public static List<string> announcementTargetAudience = new List<string>();
        public static List<int> announcementId = new List<int>();

        public static int idPos = new int();
        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();

            AddAnnouncements();
        }

        public class Announcement
        {
            public string AnnouncementTitle { get; set; }
            public string Content { get; set; }
            public int AnnouncementId { get; set; }
            public string TargetAudience { get; set; }
            public string Priority { get; set; }
        }

        public static class AnnouncementsInit
        {
            public static IList<Announcement> Announcement { get; set; }

            static AnnouncementsInit()
            {
                Announcement = new ObservableCollection<Announcement>();
            }
        }

        private void AddAnnouncements()
        {
            //announcementList.Clear();
            //announcementSender.Clear();
            //announcementContent.Clear();

            announcementList = AboutPage.announcementList;
            announcementSender = AboutPage.announcementSender;
            announcementContent = AboutPage.announcementContent;
            announcementTargetAudience = AboutPage.announcementTargetAudience;
            AnnouncementsInit.Announcement.Clear();

            int i = 0;
            foreach (string ann in announcementList)
            {
                AnnouncementsInit.Announcement.Add(new Announcement { AnnouncementTitle = ann, Content = announcementSender[i] + ": " + announcementContent[i], AnnouncementId = int.Parse(AboutPage.assignedAIds[i]) });
                i++;
            }

            //for(int x = 0; x <= announcementList.Count(); x++)
            //{
            //    AnnouncementsInit.Announcement.Add(new Announcement { AnnouncementTitle = announcementList[x], Content = announcementSender[x] + ": " + announcementContent[x] });
            //}

            ItemsInit();
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

        private async void Search_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchAnnouncements());
        }
    }
}