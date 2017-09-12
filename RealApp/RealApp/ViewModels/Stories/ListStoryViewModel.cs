using RealApp.Extentions;
using RealApp.Models;
using RealApp.Services;
using RealApp.Statics;
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
        readonly  StoryRepo _StoryRepo;

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
            _StoryRepo = new StoryRepo();
            //_DataService = DependencyService.Get<IDataService>();
            //MessagingCenter.Subscribe<Story>(this, MessagingServiceConstants.STORY, (story) =>
            //{
            //    IsInitialized = false;
            //});
        }

        Command _LoadStoriesCommand;

        /// <summary>
        /// Command to load accounts
        /// </summary>
        public Command LoadStoriesCommand
        {
            get { return _LoadStoriesCommand ?? (_LoadStoriesCommand = new Command(ExecuteLoadStoriesCommandAsync)); }
        }

        void ExecuteLoadStoriesCommandAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            LoadStoriesCommand.ChangeCanExecute();

            Stories.AddRange(
                new List<Story>()
                { new Story { Title = "Story 1", Rates = 1 },
                  new Story { Title = "Story 2", Rates = 2 },
                  new Story { Title = "Story 3", Rates = 1 },
                   new Story { Title = "Story 4", Rates = 3 },
                    new Story { Title = "Story 5", Rates = 1 },
                     new Story { Title = "Story 6", Rates = 2 },
                      new Story { Title = "Story 7", Rates = 5 },
                });

             new Task(async()=> Stories= await _StoryRepo.Get(x => x.Deleted == false, x => x.Author));

            IsBusy = false;
            LoadStoriesCommand.ChangeCanExecute();
        }
    }
}