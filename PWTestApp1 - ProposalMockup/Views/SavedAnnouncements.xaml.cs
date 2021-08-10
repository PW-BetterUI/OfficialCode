using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Collections.ObjectModel;

namespace PWTestApp1___ProposalMockup.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]


    public partial class SavedAnnouncements : ContentPage
    {
        public string AnnouncementTitle;
        public string Content;
        public string localPath = Path.Combine(FileSystem.AppDataDirectory, ItemDetailPage.savedAnnouncementFileName);
        public List<string> title = new List<string>();

        private static List<string> announcementTitleList = new List<string>();
        private static List<string> announcementContent = new List<string>();

        private static List<string> announcementTitleContentList = new List<string>();

        public SavedAnnouncements()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await DisplayAlert("WARNING!", "You are entering a page that is still under Beta Testing, meaning that the functions here may not work as intended.", "I understand and wish to proceed");
            AddSavedAnnouncements();
        }

        public class Announcement
        {
            public string AnnouncementTitle { get; set; }
            public string Content { get; set; }
        }

        public static class AnnouncementsInit
        {
            public static IList<Announcement> Announcement { get; set; }

            static AnnouncementsInit()
            {
                Announcement = new ObservableCollection<Announcement>();
            }
        }

        private void AddSavedAnnouncements()
        {
            AnnouncementsInit.Announcement.Clear();

            List<string> announcementList = File.ReadAllText(localPath).Split('#').ToList();

            foreach (string ann in announcementList)
            {
                if (ann != null || ann != "")
                {
                    announcementTitleContentList = ann.Split(',').ToList();
                    //Console.WriteLine(announcementTitleContentList[1]);


                    AnnouncementsInit.Announcement.Add(new Announcement { AnnouncementTitle = announcementTitleContentList[0], Content = announcementTitleContentList[0] });
                }
            }

            //int i = 0;
            //foreach (string ann in announcementList)
            //{
            //    AnnouncementsInit.Announcement.Add(new Announcement { AnnouncementTitle = ann, Content = announcementSender[i] + ": " + announcementContent[i] });
            //    i++;
            //}

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

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            localPath = Path.Combine(FileSystem.AppDataDirectory, ItemDetailPage.savedAnnouncementFileName);
            File.WriteAllText(localPath, null);
            Console.WriteLine("All saved announcements cleared!");
            AddSavedAnnouncements();
            await DisplayAlert("Alert", "Cleared all announcements!", "OK");
        }
    }
}