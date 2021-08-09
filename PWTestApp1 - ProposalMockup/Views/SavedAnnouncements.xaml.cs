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

            int length1 = localPath.Count();
            Console.WriteLine(length1);

            string a = File.ReadAllText(localPath);

            Console.WriteLine(a);

            string b = a.Replace(System.Environment.NewLine, ",");
            
            Console.WriteLine(b);

            title = a.Split(',').ToList();
            foreach (var i in title)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(title);
            Console.WriteLine(title[0]);

            var button = new Button();
            int length = title.Count();

            Console.WriteLine(length);
            for (int i = 0; i < length; i++)
            {
                stackLayout.Children.Add(button);
                button.Text = title[i];
                button.Clicked += delegate { DisplayAlert("Alert", "It Works! :D", "Yay!"); };
            }
            
        }
    }
}