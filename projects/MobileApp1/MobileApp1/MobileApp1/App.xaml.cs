using MobileApp1.Services;
using MobileApp1.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp1
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<NotesDataStore>();
            MainPage = new AppShell();
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
