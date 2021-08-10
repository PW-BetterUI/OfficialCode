using PWTestApp1___ProposalMockup.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using System;
using Xamarin.Essentials;
using System.Linq;
using System.Collections.Generic;

namespace PWTestApp1___ProposalMockup.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        string localPath;
        public static string title;

        private string announcementTitle;
        private string announcementContent;

        public const string savedAnnouncementFileName = "SavedAnnouncementLog.txt";

        public ItemDetailPage(string Title, string Content)
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();

            AnnouncementTitle.Text = Title;
            AnnouncementContent.Text = Content;

            announcementTitle = Title;
            announcementContent = Content;
        }

        public async void ToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("WARNING", "This function is still a Beta Function, meaning that it may not work as intended.", "I understand and wish to proceed");

            localPath = Path.Combine(FileSystem.AppDataDirectory, savedAnnouncementFileName);

            string currentFileInformation = File.ReadAllText(localPath);
            Console.WriteLine(currentFileInformation);
            File.WriteAllText(localPath, $"#{announcementTitle},{announcementContent}{currentFileInformation}");
            Console.WriteLine(File.ReadAllText(localPath));

            //using (var stream = await FileSystem.OpenAppPackageFileAsync("TheFile.txt"))
            //{
            //    using (var reader = new StreamReader(stream))
            //    {
            //        Console.WriteLine(await reader.ReadToEndAsync());
            //    }
            //}
            //string currentdir = Directory.GetCurrentDirectory();
            //string nametitle = AnnouncementTitle.Text.Replace(" ", "");
            //string namecontent = AnnouncementTitle.Text.Replace(" ", "");
            //string titlefilepath = currentdir + @"\announcementtitle\" + nametitle + ".txt";
            //string contentfilepath = currentdir + @"\announcementcontent\" + namecontent + "c.txr";

            //using (var stream = await FileSystem.OpenAppPackageFileAsync("announcementtitle"))
            //{
            //    using (var reader = new StreamReader(stream))
            //    {
            //        AnnouncementTitle.Text = await reader.readtoendasync();
            //    }
            //}



            //var location = @"C:\Users\OSdoge\source\repos\BetterUI\PWTestApp1 - ProposalMockup\Views\AnnouncementTitle\AnnouncementsTitle.json";
            //Console.WriteLine(location);

            //List<string> oldData = new List<string>();
            //List<string> newData = new List<string>();


            //string x = AnnouncementTitle.Text;

            //var oldJson = File.ReadAllLines(location);
            //oldData = new List<string>(oldJson);
            //oldData.Add(x);
            //newData = oldData;
            //File.Delete(location);
            //JsonSerializer serializer = new JsonSerializer();

            //using (StreamWriter sw = new StreamWriter(location))
            //{
            //    using (JsonWriter writer = new JsonTextWriter(sw))
            //    {
            //        serializer.Serialize(writer, newData);
            //    }
            //}

            //await DisplayAlert("Alert", "It works?", "Maybe");






            //using (var stream = await FileSystem.OpenAppPackageFileAsync(nameTitle))
            //{
            //    using (var reader = new StreamReader(stream))
            //    {
            //        await DisplayAlert("Notice", reader.ReadToEndAsync() + " has been saved", "OK");
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