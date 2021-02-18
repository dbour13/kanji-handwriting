using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace kanji.handwritting.ui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var bootstrapper = new Bootstrapper(this);
            bootstrapper.Start();
            MainPage = new MainPage();
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
