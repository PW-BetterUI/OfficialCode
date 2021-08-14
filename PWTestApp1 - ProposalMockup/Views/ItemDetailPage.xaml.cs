using PWTestApp1___ProposalMockup.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace PWTestApp1___ProposalMockup.Views
{
    public partial class ItemDetailPage : ContentPage
    {

        public int idpos = AboutPage.idPosition;
        public ItemDetailPage(string Title, string Content)
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();

            AnnouncementTitle.Text = Title;
            AnnouncementContent.Text = Content;

            Task.Delay(5000);
            ReadAnnouncement();
        }

        private void ToolbarItem_Clicked(object sender, System.EventArgs e)
        {

        }

        public void ReadAnnouncement()
        {
            
        }
    }
}