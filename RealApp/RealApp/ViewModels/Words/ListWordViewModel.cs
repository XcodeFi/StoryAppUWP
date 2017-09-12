using RealApp.Extentions;
using RealApp.Models;
using RealApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RealApp.ViewModels.Words
{
    public class ListWordViewModel : BaseViewModel
    {

        public new string Title
        {
            get { return base.Title ?? "Danh sách truyện chêm"; }
            set { base.Title = value; }
        }

        ObservableCollection<Word> _Words;
        public ObservableCollection<Word> Words
        {
            get { return _Words; }
            set
            {
                _Words = value;
                OnPropertyChanged("Words");
            }
        }

        public bool NeedsRefresh { get; set; }

        public ListWordViewModel()
        {
            _Words = new ObservableCollection<Word>();

            //_DataService = DependencyService.Get<IDataService>();
            //MessagingCenter.Subscribe<Story>(this, MessagingServiceConstants.STORY, (story) =>
            //{
            //    IsInitialized = false;
            //});
        }

        Command _LoadWordsCommand;

        /// <summary>
        /// Command to load accounts
        /// </summary>
        public Command LoadWordsCommand
        {
            get { return _LoadWordsCommand ?? (_LoadWordsCommand = new Command(ExecuteLoadWordsCommand)); }
        }

        async void ExecuteLoadWordsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            LoadWordsCommand.ChangeCanExecute();

            Words.AddRange(
                new List<Word>()
                { new Word { BaseWord = "BaseWord 1", Meaning = "Meaning 1" },
                  new Word { BaseWord = "BaseWord 2", Meaning = "Meaning 1" },
                  new Word { BaseWord = "BaseWord 3", Meaning = "Meaning 1" },
                   new Word { BaseWord = "BaseWord 4", Meaning = "Meaning 1" },
                    new Word { BaseWord = "BaseWord 5", Meaning = "Meaning 1" },
                     new Word { BaseWord = "BaseWord 6", Meaning = "Meaning 1"},
                      new Word { BaseWord = "BaseWord 7", Meaning = "Meaning 1"},
                });
            //Products = new ObservableCollection<Product>((await _DataService.GetProductsAsync(_CategoryId)));

            IsBusy = false;
            LoadWordsCommand.ChangeCanExecute();
        }
    }
}
