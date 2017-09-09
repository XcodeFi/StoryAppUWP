using RealApp.Pages.Base;
using RealApp.ViewModels.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealApp.Pages.NewWords
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListWordPage : ListWordPageXaml
    {
        public ListWordPage()
        {
            InitializeComponent();
        }
    }

    public abstract class ListWordPageXaml: ModelBoundContentPage<ListWordViewModel> { }
}