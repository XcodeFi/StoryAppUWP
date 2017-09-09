using RealApp.Pages.About;
using RealApp.Pages.NewWords;
using RealApp.Pages.Stories;
using RealApp.Statics;
using RealApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RealApp.Pages
{
    public class RootPage : MasterDetailPage
    {
        Dictionary<MenuType, NavigationPage> Pages { get; set; }
        public RootPage()
        {
            Pages = new Dictionary<MenuType, NavigationPage>();
            Master = new MenuPage(this);
            BindingContext = new BaseViewModel(Navigation)
            {
                Title = "RealApp",
                Icon = "bookshell.png"
            };
            //setup home page
            NavigateAsync(MenuType.NewWords);
        }

        void SetDetailIfNull(Page page)
        {
            if (Detail == null && page != null)
                Detail = page;
        }
        public async Task NavigateAsync(MenuType id)
        {
            Page newPage;
            if (!Pages.ContainsKey(id))
            {
                switch (id)
                {

                    case MenuType.NewWords:
                        var page = new RealAppNavigationPage(new ListWordPage
                        {
                            Title = "Tra từ mới",
                            Icon = new FileImageSource { File = "search.png" }
                        });
                        SetDetailIfNull(page);
                        Pages.Add(id, page);
                        break;
                    case MenuType.Stories:
                        page = new RealAppNavigationPage(new ListStoryPage
                        {
                            Title = "Truyện chêm",
                            Icon = new FileImageSource { File = "bookshell.png" }
                        });
                        SetDetailIfNull(page);
                        Pages.Add(id, page);
                        break;
                    case MenuType.About:
                        page = new RealAppNavigationPage(new AboutItemListPage
                        {
                            Title = "Thông tin PM",
                            Icon = new FileImageSource { File = "about.png" }
                        });
                        SetDetailIfNull(page);
                        Pages.Add(id, page);
                        break;
                }
            }
            newPage = Pages[id];
            if (newPage == null)
                return;

            //pop to root for Windows Phone
            if (Detail != null && Device.OS == TargetPlatform.WinPhone)
            {
                await Detail.Navigation.PopToRootAsync();
            }

            Detail = newPage;

            if (Device.Idiom != TargetIdiom.Tablet)
                IsPresented = false;
        }
    }

    public class RealAppNavigationPage : NavigationPage
    {
        public RealAppNavigationPage(Page root)
            : base(root)
        {
            Init();
        }

        public RealAppNavigationPage()
        {
            Init();
        }

        void Init()
        {

            BarBackgroundColor = Palette._001;
            BarTextColor = Color.White;
        }
    }
    public enum MenuType
    {
        Sales,
        Customers,
        Products,
        About,
        NewWords,
        Stories
    }

    public class HomeMenuItem
    {
        public HomeMenuItem()
        {
            MenuType = MenuType.About;
        }

        public string Icon { get; set; }

        public MenuType MenuType { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public int Id { get; set; }
    }
}