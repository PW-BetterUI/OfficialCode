using PWTestApp1___ProposalMockup.Models;
using PWTestApp1___ProposalMockup.ViewModels;
using PWTestApp1___ProposalMockup.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PWTestApp1___ProposalMockup.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
            Whymustzizhuoforcemetodothisiamverysadsadsadsad();
            
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
        private void Whymustzizhuoforcemetodothisiamverysadsadsadsad()
        {
            List<string> announcementList = AboutPage.announcementList;
            int i = announcementList.Count();
            Announcements.Children.Clear();
            for (int d = 0; d < i; d++)
            {
                Console.WriteLine(announcementList[d]);
                Announcements.Children.Add(new Button { Text = announcementList[d] });
            }
        }
    }
}