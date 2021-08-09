using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PWTestApp1___ProposalMockup.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewUpcomingEvents : ContentPage
    {
        public ViewUpcomingEvents(string event_, string startDate, string endDate)
        {
            InitializeComponent();

            EventTitle.Text = event_;
            EventStartDate.Text = $"Start Date: {startDate}";
            EventEndDate.Text = $"End Date: {endDate}";
        }
    }
}