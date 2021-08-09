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

namespace PWTestApp1___ProposalMockup.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    
    public partial class SavedAnnouncements : ContentPage
    {
        public string AnnouncementTitle;
        public string Content;
        public string localPath;
        public List<string> title = new List<string>();
        public SavedAnnouncements()
        {
            InitializeComponent();
            localPath = Path.Combine(FileSystem.AppDataDirectory, "AnnoucementTitle");
            foreach (var i in localPath)
            {
                string a = File.ReadAllText(localPath);
                title.Add(a);
            }
            foreach (var i in title)
            {
                Console.WriteLine(i);
            }
        }
    }
}