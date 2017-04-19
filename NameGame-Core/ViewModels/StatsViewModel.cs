using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillowTree.NameGame.Core.Interfaces;

namespace WillowTree.NameGame.Core.ViewModels
{
    public class StatsViewModel : MvxViewModel
    {
        private IStatsService _statsService;

        public IStatsService StatsService
        {
            get { return _statsService; }
            set
            {
                _statsService = value;
                RaisePropertyChanged(() => StatsService);
            }
        }

        public int Successes
        {
            get { return StatsService.GetSuccesses(); }
        }

        public int Misses
        {
            get { return StatsService.GetMisses(); }
        }

        public StatsViewModel(IStatsService statsService)
        {
            _statsService = statsService;
        }
    }
}
