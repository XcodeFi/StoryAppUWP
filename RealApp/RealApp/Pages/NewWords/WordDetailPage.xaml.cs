using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealApp.Pages.Base;
using RealApp.ViewModels.Words;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealApp.Pages.NewWords
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WordDetailPage : WordDetailPageXaml
    {
        public WordDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
    public abstract class WordDetailPageXaml : ModelBoundContentPage<WordViewModel> { }
}