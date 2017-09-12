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
using RealApp.Extentions;

namespace RealApp.ViewModels.Stories
{
    public class ListStoryViewModel : BaseViewModel
    {
        readonly ItemRepository _Repo;

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


            
            //try
            //{
            //    var _StoryRepo = _Repo.StoryRepo;
            //}
            //catch (Exception e)
            //{

            //    throw new Exception(e.Message);
            //}



            //_StoryRepo.Insert(new Story { Author = "author", Title = "sotry 1" });

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
            get
            {
                return _LoadStoriesCommand ?? (_LoadStoriesCommand = new Command(ExecuteLoadStoriesCommandAsync));
            }
        }

        void ExecuteLoadStoriesCommandAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            LoadStoriesCommand.ChangeCanExecute();



            Stories = App.Repository.LocalRepo.Get<Story>().ToObservableCollection();

            IsBusy = false;
            LoadStoriesCommand.ChangeCanExecute();
        }



        //Command _AddStoryCommand;

        ///// <summary>
        ///// Command to load accounts
        ///// </summary>
        //public Command AddStoryCommand
        //{
        //    get
        //    {
        //        return _AddStoryCommand ?? (_AddStoryCommand = new Command(async () => await ExecuteAddStoryCommandAsync()))
        //    }
        //}

        //async Task ExecuteAddStoryCommandAsync()
        //{
        //    if (IsBusy)
        //        return;

        //    IsBusy = true;
        //    LoadStoriesCommand.ChangeCanExecute();

        //    await _StoryRepo.Insert(_);

        //    IsBusy = false;
        //    LoadStoriesCommand.ChangeCanExecute();
        //}
    }
}