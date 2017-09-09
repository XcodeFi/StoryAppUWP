using RealApp.Models;
using RealApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RealApp.ViewModels.Stories
{
    public class ListStoryViewModel : BaseViewModel
    {
        readonly IDataService _DataService;

        public new string Title
        {
            get { return base.Title ?? "Danh sách truyện chêm"; }
            set { base.Title = value; }
        }

        ObservableCollection<Story> _Stories;
        public ObservableCollection<Story> Stories
        {
            get { return _Stories; }
            set
            {
                _Stories = value;
                OnPropertyChanged("Stories");
            }
        }

        public bool NeedsRefresh { get; set; }

        public ListStoryViewModel()
        {
            _Stories = new ObservableCollection<Story>();

            _DataService = DependencyService.Get<IDataService>();
        }

        Command _LoadStoriesCommand;

        /// <summary>
        /// Command to load accounts
        /// </summary>
        public Command LoadStoriesCommand
        {
            get { return _LoadStoriesCommand ?? (_LoadStoriesCommand = new Command(ExecuteLoadStoriesCommand)); }
        }

        async void ExecuteLoadStoriesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            LoadStoriesCommand.ChangeCanExecute();

            Stories = new ObservableCollection<Story>(
                new List<Story>()
            { new Story { Title = "Story 1", Rates = 1 },
             new Story { Title = "Story 2", Rates = 2 },
              new Story { Title = "Story 3", Rates = 1 },
               new Story { Title = "Story 4", Rates = 3 },
                new Story { Title = "Story 5", Rates = 1 },
                 new Story { Title = "Story 6", Rates = 2 },
                  new Story { Title = "Story 7", Rates = 5 },
            });
            //Products = new ObservableCollection<Product>((await _DataService.GetProductsAsync(_CategoryId)));

            IsBusy = false;
            LoadStoriesCommand.ChangeCanExecute();
        }
    }
}