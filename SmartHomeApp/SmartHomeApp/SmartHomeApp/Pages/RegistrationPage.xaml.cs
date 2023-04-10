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
	public partial class RegistrationPage : ContentPage
	{
		public RegistrationPage ()
		{
			InitializeComponent ();
		}

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());

        }

        private async void BtnReg_Clicked(object sender, EventArgs e)
        {
            string error = "";
            if (string.IsNullOrWhiteSpace(EntryLogin.Text))
                error += "Не ввели E-mail!\n";
            if (string.IsNullOrWhiteSpace(EntryPassword.Text))
                error += "Не ввели пароль!\n";
            if (string.IsNullOrWhiteSpace(EntryConfirmPassword.Text))
                error += "Вы не повторили пароль!!\n";
            if (EntryPassword.Text != EntryConfirmPassword.Text)
                error += "Пароли не совпадают!\n";
            if (string.IsNullOrWhiteSpace(EntryName.Text))
                error += "Не ввели Никнейм!\n";

            if (!string.IsNullOrEmpty(error))
            {
                await DisplayAlert("Ошибка!", "Произошла ошибка! Причины могуть быть в следующем\n\n" + error, "Ок");
                return;
            }

            Users user = new Users()
            {
                login = EntryLogin.Text,
                password = EntryPassword.Text,
                nickName = EntryName.Text
            };

            if (await ApiConnect.PostUser(user))
            {
                await DisplayAlert("Успех!", "Вы зарегистрировались!", "Ок");
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                user = null;
                await DisplayAlert("Ошибка!", "Проверьте соединение", "Ок");
                return;
             
            }
        }
    }
}