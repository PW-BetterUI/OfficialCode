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

        private static List<string> announcementList = new List<string>();
        private static List<string> announcementSender = new List<string>();
        private static List<string> announcementContent = new List<string>();

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();

            announcementList.Clear();
            announcementSender.Clear();
            announcementContent.Clear();

            AddAnnouncements();
        }

        public class Announcement
        {
            public string AnnouncementTitle { get; set; }
            public string Content { get; set; }
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

            int i = 0;
            foreach (string ann in announcementList)
            {
                AnnouncementsInit.Announcement.Add(new Announcement { AnnouncementTitle = ann, Content = announcementSender[i] + ": " + announcementContent[i] });
                i++;
            }

            ItemsInit();
        }

        private void ItemsInit()
        {
            Announcements.ItemsSource = AnnouncementsInit.Announcement;
        }

        private void Whymustzizhuoforcemetodothisiamverysadsadsadsad()
        {
            //List<string> announcementList = AboutPage.announcementList;
            //int i = announcementList.Count();
            //Announcements.Children.Clear();
            //for (int d = 0; d < i; d++)
            //{
            //    Console.WriteLine(announcementList[d]);
            //    Announcements.Children.Add(new Button { Text = announcementList[d] });
            //}
        }
    }
}