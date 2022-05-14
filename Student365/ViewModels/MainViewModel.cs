using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Student365.Commands;
using Student365.Models.Repositories;
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
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            NavigateToScheduleCommand = new NavigateCommand(_navigationStore, new ScheduleViewModel());
            NavigateToGroupViewCommand = new NavigateCommand(_navigationStore, new GroupViewModel());
            NavigateToNoteCommand = new NavigateCommand(_navigationStore, new NoteViewModel());
            NavigateToLabWorksCommand = new NavigateCommand(_navigationStore, new LabWorksViewModel());
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private ObservableCollection<NavItems> _navigationItems;

        public ObservableCollection<NavItems> NavigationItems
        {
            get
            {
                if (UnitOfWork.CurrentsUser.Role == "Admin")
                {
                    return new ObservableCollection<NavItems>
                    {
                        new NavItems
                        {
                            Name = "Schedule",
                            Kind = "Schedule",
                            Text = "Schedule"
                        },
                        new NavItems
                        {
                            Name = "Group",
                            Text= "Group",
                            Kind = "People"
                        },
                        new NavItems
                        {
                            Name = "Note",
                            Text= "Note",
                            Kind="Note"
                        },
                        new NavItems
                        {
                            Name = "LabWorks",
                            Text= "LabWorks",
                            Kind="Work"
                        }
                    };
                }

                return null;
            }
            set
            {
                _navigationItems = value;
                OnPropertyChanged(nameof(NavigationItems));
            }
        }

        private NavItems _selected;

        public NavItems Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                switch (Selected)
                {
                    case { Name: "Schedule" }:
                        NavigateToScheduleCommand.Execute(null);
                        break;

                    case { Name: "Group" }:
                        NavigateToGroupViewCommand.Execute(null);
                        break;

                    case { Name: "Note" }:
                        NavigateToNoteCommand.Execute(null);
                        break;

                    case { Name: "LabWorks" }:
                        NavigateToLabWorksCommand.Execute(null);
                        break;
                }
                OnPropertyChanged(nameof(Selected));
            }
        }

        public ICommand NavigateToScheduleCommand { get; }
        public ICommand NavigateToGroupViewCommand { get; }
        public ICommand NavigateToNoteCommand { get; }

        public ICommand NavigateToLabWorksCommand { get; }
    }

    public class NavItems
    {
        public string Name { get; set; }
        public string Kind { get; set; }

        public string Text { get; set; }
    }
}