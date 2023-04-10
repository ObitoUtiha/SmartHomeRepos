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
    public partial class DevicePage : ContentPage
    {
        public DevicePage()
        {
            InitializeComponent();

        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            LVDevice.ItemsSource = await ApiConnect.GetDeviceAsync();
        }

        private async void BtnDescription_Clicked(object sender, EventArgs e)
        {
            string descriptiontext = ((sender as Button).BindingContext as Devices).description.ToString();
             await DisplayAlert("Описание", descriptiontext, "Ок");
        }
    }
}