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

namespace WillowTree.NameGame.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private INameGameService _nameGameService;

        public NameGameViewModel NameGameViewModel;
        public MatModeViewModel MatModeViewModel;
        public ReverseNameGameViewModel ReverseNameGameViewModel;

        public MainViewModel(INameGameService nameGameService)
        {
            _nameGameService = nameGameService;

            NameGameViewModel = new NameGameViewModel();
            MatModeViewModel = new MatModeViewModel();
            ReverseNameGameViewModel = new ReverseNameGameViewModel();
        }

        public override async void Start()
        {
            base.Start();
        }
    }
}
