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
    public partial class AddEditHomePage : ContentPage
    {
        Homes _CurrentHome = new Homes();
        public AddEditHomePage(Homes homes)
        {
            InitializeComponent();
            _CurrentHome = homes;

        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            if (_CurrentHome != null)
            {
                EntryAddress.Text = _CurrentHome.fullAddress;
                EntryDescription.Text = _CurrentHome.description;
                EntryName.Text = _CurrentHome.name;
            }
        }

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            string error = "";
            if (string.IsNullOrWhiteSpace(EntryDescription.Text))
                error += "Не ввели описание проблемы!\n";
            if (string.IsNullOrWhiteSpace(EntryAddress.Text))
                error += "Не ввели описание проблемы!\n";
            if (string.IsNullOrWhiteSpace(EntryName.Text))
                error += "Не ввели описание проблемы!\n";

            if (!string.IsNullOrEmpty(error))
            {
                await DisplayAlert("Ошибка!", "Произошла ошибка! Причины могуть быть в следующем\n\n" + error, "Ок");
                return;
            }

            if (_CurrentHome != null)
            {
                _CurrentHome.description = EntryDescription.Text;
                _CurrentHome.fullAddress = EntryAddress.Text;
                _CurrentHome.name = EntryName.Text;
                if (await ApiConnect.PutHomeAsync(_CurrentHome.homeId, _CurrentHome))
                    await DisplayAlert("Успех!", "Изменения внесены успешно!", "Ок");
                else
                {
                    await DisplayAlert("Ошибка!", "Проверьте соединение", "Ок");
                    return;
                }
            }
            else
            {
                // Connector connector = new Connector();
                Homes newHome = new Homes()
                {
                    description= EntryDescription.Text,
                    fullAddress= EntryAddress.Text,
                    name= EntryName.Text,
                    owner = App.CurrentAuthtarizationUser.userId
                };
                await ApiConnect.PostHomeAsync(newHome);

                await DisplayAlert("Успех!", "Добавление прошло успешно!", "Ок");

            }
            Navigation.RemovePage(this);

        }

        private void BtnImage_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}