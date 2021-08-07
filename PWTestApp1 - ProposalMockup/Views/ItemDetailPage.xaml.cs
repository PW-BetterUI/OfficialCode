using PWTestApp1___ProposalMockup.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PWTestApp1___ProposalMockup.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage(string Title, string Content, string Priority, string Audience)
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();

            AnnouncementTitle.Text = Title;
            TargetAudience.Text = Audience;
            AnnouncementContent.Text = Content;
        }
    }
}