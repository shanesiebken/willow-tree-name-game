using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillowTree.NameGame.Core.Interfaces;

namespace WillowTree.NameGame.Core.Services
{
    public class StatsService : IStatsService
    {

        private int successes;
        private int misses;

        public void AddGuess(bool correct)
        {
            if (correct)
                successes += 1;
            else
                misses += 1;
        }

        public int GetMisses()
        {
            return misses;
        }

        public int GetSuccesses()
        {
            return successes;
        }
    }
}
