using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Student365.Commands;
using Student365.Stores;

namespace Student365.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;

        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCuurentViewModelChanged;
            NavigateToScheduleCommand = new NavigateCommand(_navigationStore, new ScheduleViewModel());
            NavigateToGroupViewCommand = new NavigateCommand(_navigationStore, new GroupViewModel());
        }

        private void OnCuurentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public ICommand NavigateToScheduleCommand { get; }
        public ICommand NavigateToGroupViewCommand { get; }
    }
}