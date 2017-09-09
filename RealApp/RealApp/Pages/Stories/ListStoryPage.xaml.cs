using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RealApp.Pages.Base;
using RealApp.ViewModels.Stories;
using RealApp.Models;

namespace RealApp.Pages.Stories
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListStoryPage : ListStoryPageXaml
    {
        public ListStoryPage()
        {
            InitializeComponent();

            BindingContext = new ListStoryViewModel();
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    if (ViewModel.IsInitialized)
        //        return;

        //    ViewModel.LoadStoriesCommand.Execute(null);
        //    ViewModel.IsInitialized = true;
        //}
        async void StoryItemTapped(object sender, ItemTappedEventArgs e)
        {
            Story story = ((Story)e.Item);

            await DisplayAlert("tap", "tapped", "ok");
            //await Navigation.PushAsync(new ProductDetailPage() { BindingContext = new ProductDetailViewModel(catalogProduct, ViewModel.IsPerformingProductSelection) { Navigation = ViewModel.Navigation } });
        }
    }

    public abstract class ListStoryPageXaml : ModelBoundContentPage<ListStoryViewModel> { }
}