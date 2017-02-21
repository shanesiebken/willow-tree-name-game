using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using WillowTree.NameGame.Core.Models;
using WillowTree.NameGame.Core.Services;

namespace WillowTree.NameGame.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private NameGameService _service;

		public MainViewModel()
        {
            _service = new NameGameService();
        }

        public override async void Start()
        {
            base.Start();
        }
    }
}
