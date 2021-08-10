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

        public string nameTitle = "announcementT.txt";
        public string nameContent = "announcementC.txt";
        public ItemDetailPage(string Title, string Content)
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();

            AnnouncementTitle.Text = Title;
            AnnouncementContent.Text = Content;
        }

        public async void ToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            //string currentdir = Directory.GetCurrentDirectory();
            //string nameTitle = AnnouncementTitle.Text.Replace(" ", "");
            //string nameContent = AnnouncementTitle.Text.Replace(" ", "");
            //string titlefilepath = currentdir + @"\announcementtitle\" + nameTitle + ".json";
            //string contentfilepath = currentdir + @"\announcementcontent\" + nameContent + "c.json";

            //Console.WriteLine(titlefilepath + "t/c " + contentfilepath);
            //JsonSerialize(AnnouncementTitle.Text, titlefilepath);
            //JsonSerialize(AnnouncementContent.Text, contentfilepath);

            //using (var stream = await FileSystem.OpenAppPackageFileAsync("announcementtitle"))
            //{
            //    using (var reader = new StreamReader(stream))
            //    {
            //        AnnouncementTitle.Text = await reader.ReadToEndAsync();
            //    }
            //}

            

            var location = Convert.ToString(FileSystem.OpenAppPackageFileAsync(nameTitle));
            Console.WriteLine(location);

            List<string> oldData = new List<string>();
            List<string> newData = new List<string>();



            var oldJson = File.ReadAllLines(location);
            oldData = new List<string>(oldJson);

            string x = AnnouncementTitle.Text;

            oldData.Add(x);
            newData = oldData;

            File.Delete(location);

            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(location))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, newData);
                }
            }



            
            
            using (var stream = await FileSystem.OpenAppPackageFileAsync(nameTitle))
            {
                using (var reader = new StreamReader(stream))
                {
                    await DisplayAlert("Notice", reader.ReadToEndAsync() + " has been saved", "OK");
                }
            }


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