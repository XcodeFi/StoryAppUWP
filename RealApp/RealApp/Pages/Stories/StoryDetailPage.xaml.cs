using RealApp.Pages.Base;
using RealApp.ViewModels.Stories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealApp.Pages.Stories
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoryDetailPage : StoryDetailPageXaml
    {
        public StoryDetailPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

    }
    public abstract class StoryDetailPageXaml : ModelBoundContentPage<StoryDetailViewModel> { }
}