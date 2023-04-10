using SmartHomeApp.Model;
using SmartHomeApp.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartHomeApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {

            Users ruser = new Users()
            {
                login = EntryLogin.Text,
                password = EntryPassword.Text
            };
            Users curUsers = new Users();

            curUsers = await ApiConnect.AuthorisationAsync(ruser);


            if (curUsers != null && curUsers.userId != 0)
            {
                App.CurrentAuthtarizationUser = curUsers;
                await Navigation.PushAsync(new MainMenuPage(curUsers));
            }
            else
            {
                await DisplayAlert("Ошибка!", "Неверный логинь или пароль!", "ок");
            }
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {

        }

        private async void BtnReg_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
    }
}
