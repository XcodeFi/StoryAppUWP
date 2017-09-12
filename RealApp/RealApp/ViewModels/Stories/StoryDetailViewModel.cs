using RealApp.Models;
using RealApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealApp.ViewModels.Stories
{
    public class StoryDetailViewModel : BaseViewModel
    {
        readonly StoryRepo _StoryRepo;
        public new string Title
        {
            get { return base.Title; }
            set { base.Title = value; }
        }

        private Story _Story;
        public Story Story
        {
            get { return _Story; }
            set
            {
                _Story = value;
                OnPropertyChanged("Story");
            }
        }

        public StoryDetailViewModel(Story storyDetail)
        {
            _Story = storyDetail;
            Title = _Story.Title;
        }

        //Command _LoadStoriesCommand;

        ///// <summary>
        ///// Command to load accounts
        ///// </summary>
        //public Command LoadStoriesCommand
        //{
        //    get { return _LoadStoriesCommand ?? (_LoadStoriesCommand = new Command(ExecuteLoadStoriesCommand)); }
        //}

        //async void ExecuteLoadStoriesCommand()
        //{
        //    if (IsBusy)
        //        return;

        //    IsBusy = true;
        //    LoadStoriesCommand.ChangeCanExecute();

        //    Stories.AddRange(
        //        new List<Story>()
        //        { new Story { Title = "Story 1", Rates = 1 },
        //          new Story { Title = "Story 2", Rates = 2 },
        //          new Story { Title = "Story 3", Rates = 1 },
        //           new Story { Title = "Story 4", Rates = 3 },
        //            new Story { Title = "Story 5", Rates = 1 },
        //             new Story { Title = "Story 6", Rates = 2 },
        //              new Story { Title = "Story 7", Rates = 5 },
        //        });
        //    //Products = new ObservableCollection<Product>((await _DataService.GetProductsAsync(_CategoryId)));

        //    IsBusy = false;
        //    LoadStoriesCommand.ChangeCanExecute();
        //}
    }
}