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
	public partial class HomesPage : ContentPage
	{
        public int userId = App.CurrentAuthtarizationUser.userId;
        public HomesPage ()
		{
			InitializeComponent ();
		}

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new AddEditHomePage(null));
        }

        private async void BtnEdit_Clicked(object sender, EventArgs e)
        {
            int ownerId = ((sender as Button).BindingContext as Homes).owner;
            if (ownerId != App.CurrentAuthtarizationUser.userId)
            {
                await DisplayAlert("Ошибка", "Только владелец дома может его редактировать ", "Ок");
                return;
            }
            await Navigation.PushAsync(new AddEditHomePage((sender as Button).BindingContext as Homes));
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            int ownerId = ((sender as Button).BindingContext as Homes).owner;
            if (ownerId != App.CurrentAuthtarizationUser.userId)
            {
                await DisplayAlert("Ошибка", "Только владелец дома может его удалить ", "Ок");
                return;
            }

            if (await DisplayAlert("Удаление", "Вы действительно хотите удалить?", "Да", "Нет"))
            {
                if (await ApiConnect.DeleteHomeAsync(((sender as Button).BindingContext as Homes).homeId))
                    await DisplayAlert("Успех!", "Удаление успешно!", "Ок");
                else
                    await DisplayAlert("Ошибка!", "Проверьте соединение", "Ок");
                LVHomes.ItemsSource = await ApiConnect.GetUserHomes(userId);
            }
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            LVHomes.ItemsSource = await ApiConnect.GetUserHomes(userId);

        }

        private void LVHomes_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}