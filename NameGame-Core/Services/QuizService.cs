using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillowTree.NameGame.Core.Interfaces;
using WillowTree.NameGame.Core.Models;

namespace WillowTree.NameGame.Core.Services
{
    public class QuizService : IQuizService
    {
        //Stats service
        private IStatsService _statsService;

        //Data service
        private INameGameService _nameGameService;

        //Quiz data fields
        private IEnumerable<Profile> _profiles;
        private Random random;

        public Profile SelectedProfile { get; set; }
        public Profile[] CurrentProfiles { get; set; }

        public QuizService(INameGameService nameGameService)
        {
            _nameGameService = nameGameService;
            _statsService = Mvx.Resolve<IStatsService>();
            random = new Random();
        }

        //Start a quiz with a certain name filter. This could be extended for a variable quiz where the user inputs a filter for names
        public async Task Start(string nameFilter)
        {
            _profiles = await _nameGameService.GetProfiles(nameFilter);
            await StartNewRound();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Resume()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        //We check the selected profile against the current selected one, adding to our stats service as appropriate
        public async Task<bool> Guess(Profile guessed)
        {
            if(guessed == SelectedProfile)
            {
                _statsService.AddGuess(true);
                return true;
            }
            _statsService.AddGuess(false);
            return false;
        }

        //Refresh the profiles and select a new "target"
        public async Task StartNewRound()
        {
            //This randomization wouldn't scale well, say, for a large company doing a name game but it works for these purposes
            CurrentProfiles = _profiles.OrderBy(x => random.Next()).Take(5).ToArray();

            SelectedProfile = CurrentProfiles[random.Next(5)];
            Debug.WriteLine(SelectedProfile.FirstName + ' ' + SelectedProfile.LastName);
        }

        public Profile[] GetCurrentProfiles()
        {
            return CurrentProfiles;
        }

        public Profile GetSelectedProfile()
        {
            return SelectedProfile;
        }
    }
}
