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
            get { return _LoadStoriesCommand ?? (_LoadStoriesCommand = new Command(ExecuteLoadProductsCommand)); }
        }

        async void ExecuteLoadProductsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            //LoadProductsCommand.ChangeCanExecute();

            //Products = new ObservableCollection<Product>((await _DataService.GetProductsAsync(_CategoryId)));

            IsBusy = false;
            LoadStoriesCommand.ChangeCanExecute();
        }
    }
}