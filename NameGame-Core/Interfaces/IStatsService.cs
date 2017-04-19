using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WillowTree.NameGame.Core.Interfaces
{
    public interface IStatsService
    {
        void AddGuess(bool correct);

        int GetSuccesses();
        int GetMisses();
    }
}
