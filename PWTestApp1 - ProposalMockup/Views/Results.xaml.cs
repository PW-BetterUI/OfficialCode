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
			ABC.Text = "Zizhuo </3 Siting";
		}
	}
}