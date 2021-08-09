using PWTestApp1___ProposalMockup.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System;
using Xamarin.Essentials;
using System.Linq;

namespace PWTestApp1___ProposalMockup.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        string localPath;
        public static string title;
        public ItemDetailPage(string Title, string Content)
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();

            AnnouncementTitle.Text = Title;
            AnnouncementContent.Text = Content;
        }

        private async void ToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            string currentdir = Directory.GetCurrentDirectory();
            string nameTitle = AnnouncementTitle.Text.Replace(" ", "");
            string nameContent = AnnouncementTitle.Text.Replace(" ", "");
            string titlefilepath = currentdir + @"\announcementtitle\" + nameTitle + ".json";
            string contentfilepath = currentdir + @"\announcementcontent\" + nameContent + "c.json";

            Console.WriteLine(titlefilepath + "t/c " + contentfilepath);
            JsonSerialize(AnnouncementTitle.Text, titlefilepath);
            JsonSerialize(AnnouncementContent.Text, contentfilepath);

            using (var stream = await FileSystem.OpenAppPackageFileAsync("announcementtitle"))
            {
                using (var reader = new StreamReader(stream))
                {
                    AnnouncementTitle.Text = await reader.ReadToEndAsync();
                }
            }
        }

        public void JsonSerialize(object data, string filepath)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
            StreamWriter sw = new StreamWriter(filepath);
            JsonWriter jsonWriter = new JsonTextWriter(sw);

            jsonSerializer.Serialize(jsonWriter, data);

            jsonWriter.Close();
            sw.Close();
        }
    }
}