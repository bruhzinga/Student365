using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Windows.Input;
using Student365.Commands.GradeControlVIewModel;
using Student365.Models;
using Student365.Models.Repositories;

namespace Student365.ViewModels
{
    public class GradeViewModel : BaseViewModel, IDataErrorInfo
    {
        public ObservableCollection<Custom> Subjects
        {
            get => _subjects;
            set
            {
                _subjects = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Custom> _subjects;

        private ObservableCollection<string> _subjects_list;

        public ObservableCollection<string> Subjects_list
        {
            get => _subjects_list;
            set
            {
                _subjects_list = value;
                OnPropertyChanged();
            }
        }

        private string _newSubject;

        public string NewSubject
        {
            get => _newSubject;
            set
            {
                _newSubject = value;
                OnPropertyChanged();
            }
        }

        private string _grade;

        public string Grade
        {
            get => _grade;
            set
            {
                _grade = value;
                OnPropertyChanged();
            }
        }

        private KeyValuePair<int, short> _selected;

        public KeyValuePair<int, short> Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }

        public ICommand Remove { get; }

        public GradeViewModel()
        {
            GetSubjects();
            Subjects_list = new ObservableCollection<string>(
                UnitOfWork.GroupSubjectsRepository.GetAllSubjectsByGroupId(UnitOfWork.StudentsRepository
                    .GetCurrentUserGroup(), UnitOfWork.StudentsRepository.GetCurrentUserKurs()).Select(x => x.Subject));
            AddCommand = new AddGradeCommand(this);
            Remove = new RemoverGradeCommnad(this);
        }

        string IDataErrorInfo.Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                string error = null;

                switch (columnName)
                {
                    case nameof(Grade):
                        var grade = int.TryParse(Grade, out int n);
                        if (!grade)
                            return "Неверный формат оценки";
                        // Validate property and return a string if there is an error
                        if (n > 10 || n < 1)
                        {
                            return "Оценка должна быть в диапазоне от 0 до 10";
                        }

                        break;

                    case nameof(NewSubject):
                        if (string.IsNullOrWhiteSpace(NewSubject))
                            error = "Не может быть пустым";
                        break;
                }

                return error;
            }
        }

        public void GetSubjects()
        {
            Subjects = new ObservableCollection<Custom>();
            var grades = UnitOfWork.GradeRepository.GetAllGradesByCurrentUser();
            var subjects = grades.Select(x => x.subject).Distinct();
            foreach (var subject in subjects)
            {
                Subjects.Add(new Custom()
                {
                    Subject = subject,
                    Grades = grades.Where(x => x.subject == subject)
                        .ToDictionary(x => x.id, x => x.grade1)
                });
            }
        }

        public class Custom : BaseViewModel
        {
            private Dictionary<int, short> _grades;

            public Dictionary<int, short> Grades

            {
                get => _grades;
                set
                {
                    _grades = value;
                    OnPropertyChanged();
                }
            }

            private string _subject;

            public string Subject
            {
                get => _subject;
                set
                {
                    _subject = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}