using PWTestApp1___ProposalMockup.Models;
using PWTestApp1___ProposalMockup.ViewModels;
using PWTestApp1___ProposalMockup.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        List<string> Items;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
            Whymustzizhuoforcemetodothisiamverysadsadsadsad();
            //InitList();
            T();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        //void InitList()
        //{
        //    Items = AboutPage.announcementList;

        //    Announcements.ItemsSource = Items;
        //}

        public class Player
        {
            public string Name { get; set; }
            public string Position { get; set; }
            public string Team { get; set; }
        }

        public static class PlayersFactory
        {
            public static IList<Player> Players { get; set; }

            static PlayersFactory()
            {
                Players = new ObservableCollection<Player>()
                {
                    new Player
                    {
                        Name = "Gamer",
                        Position = "gamer",
                        Team = "Gamer gang"
                    }
                };
            }
        }

        private void U()
        {
            //PlayersFactory.Players.Add
        }

        private void T()
        {
            Announcements.ItemsSource = PlayersFactory.Players;
        }

        private void Whymustzizhuoforcemetodothisiamverysadsadsadsad()
        {
            //List<string> announcementList = AboutPage.announcementList;
            //int i = announcementList.Count();
            //Announcements.Children.Clear();
            //for (int d = 0; d < i; d++)
            //{
            //    Console.WriteLine(announcementList[d]);
            //    Announcements.Children.Add(new Button { Text = announcementList[d] });
            //}
        }
    }
}