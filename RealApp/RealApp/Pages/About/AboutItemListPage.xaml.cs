using RealApp.Pages.Base;
using RealApp.ViewModels;
using RealApp.ViewModels.About;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealApp.Pages.About
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutItemListPage : AboutItemListPageXaml
    {
        public AboutItemListPage()
        {

            BindingContext = new AboutItemListViewModel();
            Title = "About";
            InitializeComponent();
            AboutItemList.ItemSelected += (sender, e) => AboutItemList.SelectedItem = null;
        }

        async void AboutItemTapped(object sender, ItemTappedEventArgs e)
        {
            AboutItemViewModel vm = ((AboutItemViewModel)e.Item);
            vm.Navigation = this.Navigation;
            await Navigation.PushAsync(new AboutDetailPage() { BindingContext = vm });
        }
    }

    public abstract class AboutItemListPageXaml: ModelBoundContentPage<AboutItemListViewModel> { }
}