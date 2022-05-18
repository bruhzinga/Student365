using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Student365.Commands.SubjectSetterCommand;
using Student365.Models;
using Student365.Models.Repositories;

namespace Student365.ViewModels
{
    public class SubjectSetterViewModel : BaseViewModel
    {
        private ObservableCollection<Subject> _subjects;

        public ObservableCollection<Subject> Subjects
        {
            get => _subjects;
            set
            {
                _subjects = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _groupSubjects;

        public ObservableCollection<string> GroupSubjects
        {
            get => _groupSubjects;
            set
            {
                _groupSubjects = value;
                OnPropertyChanged();
            }
        }

        private string _group;

        public string Group
        {
            get => _group;
            set
            {
                _group = value ?? "1";
                if (!(_group == String.Empty))
                    GroupSubjects = UnitOfWork.GroupSubjectsRepository.GetAllSubjectsNamesByGroupId(Convert.ToInt32((_group)));
                OnPropertyChanged(nameof(GroupSubjects));
                OnPropertyChanged();
            }
        }

        public ICommand Sync { get; }

        public ICommand AddToSelected { get; }

        public SubjectSetterViewModel()
        {
            _subjects = UnitOfWork.GroupSubjectsRepository.GetAllSubjects();
            Sync = new SyncCommand(this);
            AddToSelected = new AddToSelectedCommand(this);
        }
    }
}