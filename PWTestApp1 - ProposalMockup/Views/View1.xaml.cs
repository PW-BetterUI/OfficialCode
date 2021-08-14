using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.CommunityToolkit.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PWTestApp1___ProposalMockup.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class View1 : ContentView
    {
        public View1()
        {
            InitializeComponent();
            //mediaSource.Source = GetYouTubeUrl("eLLfOVkp6so");
        }
        public string GetYouTubeUrl(string videoId)
        {
            var videoInfoUrl = $"https://www.youtube.com/get_video_info?video_id={videoId}";
            using (var client = new HttpClient())
            {
                var videoPageContent = client.GetStringAsync(videoInfoUrl).Result;
                var videoParameters = HttpUtility.ParseQueryString(videoPageContent);
                var encodedStreamsDelimited1 = WebUtility.HtmlDecode(videoParameters["player_response"]);
                JObject jObject = JObject.Parse(encodedStreamsDelimited1);
                string url = (string)jObject["streamingData"]["formats"][0]["url"];
                return url;
            }
        }
    }
}