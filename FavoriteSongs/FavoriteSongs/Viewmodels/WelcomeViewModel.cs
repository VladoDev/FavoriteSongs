using System;
using System.Collections.ObjectModel;
using FavoriteSongs.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace FavoriteSongs.Viewmodels
{
    public class WelcomeViewModel : BindableBase
    {
        private bool _isListVisible;
        public bool IsListVisible { get { return _isListVisible; } set { SetProperty(ref _isListVisible, value); } }
        private bool _isMessageVisible;
        public bool IsMessageVisible { get { return _isMessageVisible; } set { SetProperty(ref _isMessageVisible, value); } }
        private bool _showAddPopup;
        public bool ShowAddPopup { get { return _showAddPopup; } set { SetProperty(ref _showAddPopup, value); } }
        private string _songTitle;
        public string SongTitle { get { return _songTitle; } set { SetProperty(ref _songTitle, value); } }
        private string _songArtist;
        public string SongArtist { get { return _songArtist; } set { SetProperty(ref _songArtist, value); } }
        private int _songYear;
        public int SongYear { get { return _songYear; } set { SetProperty(ref _songYear, value); } }
        private string _songGender;
        public string SongGender { get { return _songGender; } set { SetProperty(ref _songGender, value); } }

        public DelegateCommand AddNewSongCommand { get; set; }
        public DelegateCommand AddingNewSongCommand { get; set; }
        public DelegateCommand<SongInformation> DeleteSongCommand { get; set; }
        private ObservableCollection<SongInformation> _myFavoriteSongs;
        public ObservableCollection<SongInformation> MyFavoriteSongs { get { return _myFavoriteSongs; } set { SetProperty(ref _myFavoriteSongs, value); } }

        public WelcomeViewModel()
        {
            MyFavoriteSongs = new ObservableCollection<SongInformation>();
            AddNewSongCommand = new DelegateCommand(AddNewSong);
            AddingNewSongCommand = new DelegateCommand(AddingNewSong);
            DeleteSongCommand = new DelegateCommand<SongInformation>(DeleteSong);
            ShowAddPopup = false;
            ShowListOrEmptyMessage();
        }

        private void DeleteSong(SongInformation obj)
        {
            MyFavoriteSongs.Remove(obj);
            ShowListOrEmptyMessage();
        }

        private void AddingNewSong()
        {
            var random = new Random();
            if (!string.IsNullOrEmpty(SongArtist) && !string.IsNullOrEmpty(SongArtist) && !string.IsNullOrEmpty(SongGender) && SongYear != 0)
            {
                MyFavoriteSongs.Add(new SongInformation()
                {
                    SongArtist = SongArtist,
                    SongArtisFirstLetter = SongArtist.Substring(0, 1),
                    SongColor = String.Format("#{0:X6}", random.Next(0x1000000)),
                    SongGender = SongGender,
                    SongNumber = MyFavoriteSongs.Count + 1,
                    SongTitle = SongTitle,
                    SongYear = SongYear
                });
                ShowAddPopup = false;
                SongArtist = string.Empty;
                SongGender = string.Empty;
                SongTitle = string.Empty;
                SongYear = 0;
            }
            ShowListOrEmptyMessage();
        }

        private void AddNewSong()
        {
            ShowAddPopup = !ShowAddPopup;
        }

        private void ShowListOrEmptyMessage()
        {
            if (MyFavoriteSongs?.Count > 0)
            {
                IsListVisible = true;
                IsMessageVisible = !IsListVisible;
            }
            else
            {

                IsListVisible = false;
                IsMessageVisible = !IsListVisible;
            }
        }
    }
}

