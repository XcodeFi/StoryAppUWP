using RealApp.Pages.Base;
using RealApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : LoginPageXaml
    {
        public LoginPage()
        {
            BindingContext = new LoginViewModel();

            Title = "Đăng nhập";
            
            ViewModel.LoginCommand = new Command(async () =>
            {
                try
                {
                    await ViewModel.Login();

                    App.GoToRoot();
                }
                catch (Exception exc)
                {
                    await DisplayAlert("Có lỗi", exc.Message, "Đóng");
                }
            });

            InitializeComponent();
        }
    }
    public abstract class LoginPageXaml : ModelBoundContentPage<LoginViewModel>
    {
    }
}