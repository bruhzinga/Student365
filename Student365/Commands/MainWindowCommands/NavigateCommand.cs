using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Student365.Stores;
using Student365.ViewModels;

namespace Student365.Commands
{
    internal class NavigateCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly BaseViewModel _model;

        public NavigateCommand(NavigationStore navigationStore, BaseViewModel model)
        {
            _navigationStore = navigationStore;
            _model = model;
        }

        public override void Execute(object? parameter)

        {
            _navigationStore.CurrentViewModel = _model;
        }
    }
}