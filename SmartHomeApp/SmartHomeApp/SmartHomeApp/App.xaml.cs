using SmartHomeApp.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartHomeApp
{
    public partial class App : Application
    {
        public static Users CurrentAuthtarizationUser { get; set; } = null;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
