using Plugin.Connectivity;
using RealApp.Localization;
using RealApp.Pages;
using RealApp.Pages.About;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RealApp
{
    public partial class App : Application
    {

        static SQLiteAsyncConnection _DbConnection;
        static Application _app;

        public static Application CurrentApp
        {
            get { return _app; }
        }

        public static SQLiteAsyncConnection DbConnection
        {
            get
            {
                if (_DbConnection == null)
                {
                    _DbConnection = DependencyService.Get<IDatabaseAccess>().GetConnection();
                }
                return _DbConnection;
            }
        }

        public App()
        {
            InitializeComponent();

            _app = this;

            MainPage = new RootPage();
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


        public static async Task ExecuteIfConnected(Func<Task> actionToExecuteIfConnected)
        {
            if (IsConnected)
            {
                await actionToExecuteIfConnected();
            }
            else
            {
                await ShowNetworkConnectionAlert();
            }
        }

        static async Task ShowNetworkConnectionAlert()
        {
            await CurrentApp.MainPage.DisplayAlert(
                TextResources.NetworkConnection_Alert_Title,
                TextResources.NetworkConnection_Alert_Message,
                TextResources.NetworkConnection_Alert_Confirm);
        }

        public static bool IsConnected
        {
            get { return CrossConnectivity.Current.IsConnected; }
        }

        public static int AnimationSpeed = 250;





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
