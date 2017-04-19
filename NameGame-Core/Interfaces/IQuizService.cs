using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillowTree.NameGame.Core.Models;

namespace WillowTree.NameGame.Core.Interfaces
{
    public interface IQuizService
    {
        Task Start(string names);

        void Pause();

        void Resume();

        void Stop();

        Task<bool> Guess(Profile profile);

        Task StartNewRound();

        Profile[] GetCurrentProfiles();

        Profile GetSelectedProfile();
    }
}
