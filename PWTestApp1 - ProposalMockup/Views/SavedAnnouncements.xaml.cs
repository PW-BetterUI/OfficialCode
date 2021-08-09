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
        }
    }
}