using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PWTestApp1___ProposalMockup.Views
{
    public partial class AboutPage : ContentPage
    {

        public AboutPage()
        {
            StackLayout stackLayout = Announcements;
            InitializeComponent();
        }

        public void countButton(System.Object sender, System.EventArgs e)
        {
            int c = Int32.Parse(buttonNum.Text);
            for(int i = 0; i <= c; i++)
            {
                Console.WriteLine(i);
            }
            //StackLayout parent;
            //try
            //{
            //    int count = Convert.ToInt32(buttonNum.Text);

            //    Button button = new Button
            //    {
            //        BackgroundColor = Color.White,
            //        Text = "I'm gamer",
            //        TextColor = Color.Black
            //    };

            //    parent = Announcements;

            //    //for(int i = 0; i < count; i++)
            //    //{
            //    //    parent.Children.Add(button);
            //    //    Console.WriteLine(Announcements.Children.Count);
            //    //}
            //    int x = 0;
            //    while(x < 10)
            //    {
            //        Console.WriteLine(Announcements.Children.Count);
            //        parent.Children.Add(button);
            //        Console.WriteLine(Announcements.Children.Count);
            //        x++;
            //    }
            //}
            //catch
            //{
            //    Console.WriteLine("something went wrong please try again");
            //}
        }       
    }
}