﻿using Google.Apis.Auth.OAuth2;
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
        public static List<int> announcementId = new List<int>();

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
            public int AnnouncementId { get; set; }
            public string Content { get; set; }
            public string Tags { get; set; }
        }

        private void AddAnnouncements()
        {
            announcementList = AboutPage.announcementList;
            announcementSender = AboutPage.announcementSender;
            announcementContent = AboutPage.announcementContent;
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

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchresult = AnnouncementsInit.Announcement.Where(c => c.Tags.ToLower().Contains(SearchAnnouncementBar.Text));
            Announcements.ItemsSource = searchresult;
        }
    }
}