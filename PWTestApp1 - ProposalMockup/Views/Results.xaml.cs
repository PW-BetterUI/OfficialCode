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
	
	public partial class Results : ContentPage
	{
		public Results ()
		{
			InitializeComponent ();

		}

        private void Button_Clicked(object sender, EventArgs e)
        {
			if (Secondary1.IsVisible == true)
			{
				Secondary1.IsVisible = false;
            }
			else if (Secondary1.IsVisible == false)
            {
				Secondary1.IsVisible = true;

			}
        }
    }
}