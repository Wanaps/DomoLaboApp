using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DomoLabo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            Console.WriteLine("nique ta mere la pute de ta race de ta mere la pute");
        }


        private void StationPage_OnTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StationPage());
        }
    }
}