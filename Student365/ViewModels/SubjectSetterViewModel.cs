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

        private ObservableCollection<GroupSubject> _groupSubjects;

        public ObservableCollection<GroupSubject> GroupSubjects
        {
            get => _groupSubjects;
            set
            {
                _groupSubjects = value;
                OnPropertyChanged();
            }
        }

        private int _group;

        public int Group
        {
            get => _group;
            set
            {
                _group = value;
                if (_group != 0)
                    GroupSubjects = UnitOfWork.GroupSubjectsRepository.GetAllSubjectsByGroupId(_group, Kurs);
                OnPropertyChanged(nameof(GroupSubjects));
                OnPropertyChanged();
            }
        }

        public ICommand Sync { get; }

        public ICommand AddToSelected { get; }

        public ICommand DeleteGroupSubject { get; }

        public ICommand DeleteSubject { get; }

        private GroupSubject _selectedGroupSubject;

        public GroupSubject SelectedGroupSubject
        {
            get => _selectedGroupSubject;
            set
            {
                _selectedGroupSubject = value;
                OnPropertyChanged();
            }
        }

        private Subject _selectedSubject;

        public Subject SelectedSubject
        {
            get => _selectedSubject;
            set
            {
                _selectedSubject = value;
                OnPropertyChanged();
            }
        }

        private short _kurs;

        public short Kurs
        {
            get => _kurs;
            set
            {
                _kurs = value;
                GroupSubjects = UnitOfWork.GroupSubjectsRepository.GetAllSubjectsByGroupId(_group, Kurs);
                OnPropertyChanged();
            }
        }

        public ICommand ChangeMaxLabs { get; }

        public SubjectSetterViewModel()
        {
            Subjects = UnitOfWork.GroupSubjectsRepository.GetAllSubjects(Kurs);
            Sync = new SyncCommand(this);
            AddToSelected = new AddToSelectedCommand(this);
            DeleteGroupSubject = new DeleteGroupSubjectCommand(this);
            DeleteSubject = new DeleteSubjectCommand(this);
            ChangeMaxLabs = new ChangeMaxLabsCommand(this);
        }
    }
}