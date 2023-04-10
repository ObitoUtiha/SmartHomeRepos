using SmartHomeApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartHomeApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMenuPage : ContentPage
	{
        Users _currentUser = new Users();

        public MainMenuPage (Users user)
		{
			InitializeComponent ();
            _currentUser = user;
        }

        private async void Homes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomesPage());
        }

        private async void BtnHomes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomesPage());

        }

        private void BtnUser_Clicked(object sender, EventArgs e)
        {

        }

        private async void BtnDevices_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DevicePage());
        }
    }
}