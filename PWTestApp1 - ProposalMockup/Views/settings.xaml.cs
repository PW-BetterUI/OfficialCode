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
                Yes.Text = "Its WOrking nice";
                Application.Current.UserAppTheme = OSAppTheme.Dark;
            }
        }
    }
}