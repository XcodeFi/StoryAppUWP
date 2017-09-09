using RealApp.Pages.Base;
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
    public partial class AboutDetailPage : AboutDetailPageXaml
    {
        public AboutDetailPage()
        {
            InitializeComponent();
        }
    }
    public class AboutDetailPageXaml : ModelBoundContentPage<AboutItemViewModel> { }
}