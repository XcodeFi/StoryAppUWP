using RealApp.Pages;
using RealApp.Pages.About;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace RealApp
{
    public partial class App : Application
    {

        static Application app;
        public static Application CurrentApp
        {
            get { return app; }
        }

        public App()
        {

            InitializeComponent();

            app = this;
            MainPage = new LoginPage();
        }
        public static void GoToRoot()
        {
            if (Device.OS == TargetPlatform.iOS)
            {
                //CurrentApp.MainPage = new RootTabPage();
            }
            else
            {
                CurrentApp.MainPage = new RootPage();
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
