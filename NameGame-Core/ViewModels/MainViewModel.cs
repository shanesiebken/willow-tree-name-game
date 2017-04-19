using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using WillowTree.NameGame.Core.Models;
using WillowTree.NameGame.Core.Interfaces;
using MvvmCross.Platform;

namespace WillowTree.NameGame.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {

        public NameGameViewModel NameGameViewModel;
        public NameGameViewModel MatModeViewModel;
        public NameGameViewModel ReverseNameGameViewModel;
        public StatsViewModel StatsViewModel;

        public MainViewModel()
        {
            NameGameViewModel = new NameGameViewModel(Mvx.Resolve<IQuizService>(),"");
            MatModeViewModel = new NameGameViewModel(Mvx.Resolve<IQuizService>(),"Mat");
            ReverseNameGameViewModel = new NameGameViewModel(Mvx.Resolve<IQuizService>(), "", true);
            StatsViewModel = new StatsViewModel(Mvx.Resolve<IStatsService>());
        }

        public override async void Start()
        {
            base.Start();
        }
    }
}
