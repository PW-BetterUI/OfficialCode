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
    public partial class settings : ContentPage
    {
        public settings()
        {
            InitializeComponent();
        }
        public void Yes_Tapped(object sender, EventArgs e)
        {
            if (DarkMode.On == true)
            {
                Console.WriteLine("DarkMode on");
                Application.Current.UserAppTheme = OSAppTheme.Dark;
            }
            else if (DarkMode.On == false)
            {
                Application.Current.UserAppTheme = OSAppTheme.Light;
            }

            if (Settings2.On == true)
            {
                //To Be Added
            }
            else if (Settings2.On == false)
            {
                //To Be Added
            }
        }
    }
}