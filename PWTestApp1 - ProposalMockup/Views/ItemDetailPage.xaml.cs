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

        private void ToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            //string currentDir = Directory.GetCurrentDirectory();

            //string titleFilepath = currentDir + @"\AnnouncementTitle";
            //string contentFilepath = currentDir + @"\AnnouncementContent";

            //Console.WriteLine(titleFilepath + "T/C " + contentFilepath);
            //JsonSerialize(AnnouncementTitle.Text, titleFilepath);
            //JsonSerialize(AnnouncementContent.Text, contentFilepath);
            title = AnnouncementTitle.Text;
            localPath = Path.Combine(FileSystem.AppDataDirectory , "AnnoucementTitle");
            File.WriteAllText(localPath, AnnouncementTitle.Text);

            //using (var stream = await FileSystem.OpenAppPackageFileAsync("AnnouncementTitle"))
            //{
            //    using (var reader = new StreamReader(stream))
            //    {
            //        AnnouncementTitle.Text = await reader.ReadToEndAsync();
            //    }
            //}
        }

        //public void JsonSerialize(object data, string filepath)
        //{
        //    JsonSerializer jsonSerializer = new JsonSerializer();
        //    if (File.Exists(filepath))
        //    {
        //        File.Delete(filepath);
        //    }
        //    StreamWriter sw = new StreamWriter(filepath);
        //    JsonWriter jsonWriter = new JsonTextWriter(sw);

        //    jsonSerializer.Serialize(jsonWriter, data);

        //    jsonWriter.Close();
        //    sw.Close();
        //}
    }
}