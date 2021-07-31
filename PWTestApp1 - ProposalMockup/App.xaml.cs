using PWTestApp1___ProposalMockup.Services;
using PWTestApp1___ProposalMockup.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PWTestApp1___ProposalMockup
{
    public partial class App : Application
    {
        //static ProjectDatabase database;

        //public static ProjectDatabase Database
        //{
        //    get
        //    {
        //        if(database == null)
        //        {
        //            database = new ProjectDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PWTestApp1___ProposalMockup.db3"));
        //        }
        //        return database;
        //    }
        //}
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage();

            Device.SetFlags(new string[] { "AppTheme_Experimental" });
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
