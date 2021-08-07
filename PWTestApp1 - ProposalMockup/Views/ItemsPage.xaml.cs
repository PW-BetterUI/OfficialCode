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

        private static List<string> announcementList = AboutPage.announcementList;
        private static List<string> announcementSender = AboutPage.announcementSender;
        private static List<string> announcementContent = AboutPage.announcementContent;

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

        public class Player
        {
            public string AnnouncementTitle { get; set; }
            public string Content { get; set; }
            public string Priority { get; set; }
        }

        public static class AnnouncementsInit
        {
            public static IList<Player> Players { get; set; }

            static AnnouncementsInit()
            {
                Players = new ObservableCollection<Player>();
            }
        }

        private void AddAnnouncements()
        {
            //announcementList.Clear();
            //announcementSender.Clear();
            //announcementContent.Clear();

            //announcementList = AboutPage.announcementList;
            //announcementSender = AboutPage.announcementSender;
            //announcementContent = AboutPage.announcementContent;

            int i = 0;
            foreach (string ann in announcementList)
            {
                AnnouncementsInit.Players.Add(new Player { AnnouncementTitle = ann, Content = announcementSender[i] + ": " + announcementContent[i] });
                i++;
            }
            //PlayersFactory.Players.Add(new Player { AnnouncementTitle = "Gamer", Position = "Gamer occupation", Team = "Gamer gang" });

            ItemsInit();
        }

        private void ItemsInit()
        {
            Announcements.ItemsSource = AnnouncementsInit.Players;
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