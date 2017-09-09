using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RealApp.Pages.Base;
using RealApp.ViewModels.Stories;

namespace RealApp.Pages.Stories
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListStoryPage : ListStoryPageXaml
    {
        public ListStoryPage()
        {
            InitializeComponent();
        }
    }

    public abstract class ListStoryPageXaml : ModelBoundContentPage<ListStoryViewModel> { }
}