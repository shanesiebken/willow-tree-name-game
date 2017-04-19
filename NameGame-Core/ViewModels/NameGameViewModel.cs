using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillowTree.NameGame.Core.Interfaces;
using WillowTree.NameGame.Core.Models;

namespace WillowTree.NameGame.Core.ViewModels
{
    public class NameGameViewModel : MvxViewModel
    {
        private IQuizService _quizService;
        private string _nameFilter;
        public bool Reverse;

        private ObservableCollection<ProfileViewModel> _profileViewModels;
        public ObservableCollection<ProfileViewModel> ProfileViewModels
        {
            get { return _profileViewModels; }
            set
            {
                _profileViewModels = value;
                RaisePropertyChanged(() => ProfileViewModels);
            }
        }

        private Profile _selectedProfile;

        public Profile SelectedProfile
        {
            get { return _selectedProfile; }
            set {
                _selectedProfile = value;
                RaisePropertyChanged(() => SelectedProfile);
            }
        }

        public NameGameViewModel(IQuizService quizService, string nameFilter, bool reverse = false)
        {
            _quizService = quizService;
            _nameFilter = nameFilter;
            Reverse = reverse;
        }

        public override async void Start()
        {
            if (ProfileViewModels == null)
            {
                await _quizService.Start(_nameFilter);
                SetProfiles();
            }
            base.Start();
        }

        //Refresh the set of current profiles and the "target"
        private void SetProfiles()
        {
            ProfileViewModels = new ObservableCollection<ProfileViewModel>(_quizService.GetCurrentProfiles().Select(p => new ProfileViewModel(p)));
            Debug.WriteLine(ProfileViewModels.Count());
            SelectedProfile = _quizService.GetSelectedProfile();
        }

        private MvxAsyncCommand<ProfileViewModel> _guessCommand;

        public IMvxAsyncCommand GuessCommand
        {
            get
            {
                _guessCommand = _guessCommand ?? new MvxAsyncCommand<ProfileViewModel>(profileViewModel => DoGuessAsync(profileViewModel));
                return _guessCommand;
            }
        }

        //We wait for the result of the guess (true/false) and update viewmodels or the profile list, depending on the type of quiz we are playing
        private async Task DoGuessAsync(ProfileViewModel profileViewModel)
        {
            var result = await _quizService.Guess(profileViewModel.Profile);
            Debug.WriteLine(result);
            profileViewModel.Visible = true;
            if (result == true)
            {
                if (!Reverse) //Trigger animation for non-reverse name game
                    profileViewModel.TintAnimation = 1;
                else {
                    // Remove all but correct name from list for reverse name game
                    var itemsToRemove = ProfileViewModels.Where(p => p != profileViewModel).ToList();
                    foreach (var item in itemsToRemove) {
                        ProfileViewModels.Remove(item);
                    }

                }

                await _quizService.StartNewRound();
                await Task.Delay(1500);
                ProfileViewModels.Clear();
                SetProfiles();
            }
            else
            {
                if (!Reverse)
                    profileViewModel.TintAnimation = 0;
                else
                    ProfileViewModels.Remove(profileViewModel);
            }

        }
    }
}
