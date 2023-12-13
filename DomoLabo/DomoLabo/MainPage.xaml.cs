using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;
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
            Navigation.ShowPopupAsync(new PopupHub());
        }


        private void StationPage_OnTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StationPage());
        }
    }
}