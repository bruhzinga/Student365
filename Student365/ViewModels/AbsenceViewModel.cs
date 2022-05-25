using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Student365.Commands.AbsenceCommands;
using Student365.Models;
using Student365.Models.Repositories;

namespace Student365.ViewModels
{
    public class AbsenceViewModel : BaseViewModel, IDataErrorInfo
    {
        private ObservableCollection<string> _subjectsList;

        public ObservableCollection<string> SubjectList
        {
            get { return _subjectsList; }
            set
            {
                _subjectsList = value;
                OnPropertyChanged("SubjectList");
            }
        }

        private string _reason;

        public string Reason
        {
            get
            {
                return _reason;
            }

            set
            {
                _reason = value;
                OnPropertyChanged(nameof(Reason));
            }
        }

        private ObservableCollection<Absence> _absences;

        public ObservableCollection<Absence> Absences
        {
            get { return _absences; }
            set
            {
                _absences = value;
                OnPropertyChanged(nameof(Absences));
            }
        }

        public string Selected { get; set; }

        private DateTime _date;

        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        private Dictionary<string, int> _AbsenceCount;

        public Dictionary<string, int> AbsenceCount
        {
            get { return _AbsenceCount; }
            set
            {
                _AbsenceCount = value;
                OnPropertyChanged(nameof(AbsenceCount));
            }
        }

        public ICommand AddAbsenceCommand { get; set; }

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
                    case nameof(Reason):
                        if (string.IsNullOrEmpty(Reason))
                        {
                            error = "Поле не может быть пустым";
                            break;
                        }
                        if (Reason?.Length > 30)
                        {
                            error = "Поле не может быть длиннее 30 cимволов";
                        }

                        break;

                    case nameof(Selected):
                        if (string.IsNullOrEmpty(Selected))
                        {
                            error = "Поле не может быть пустым";
                            break;
                        }

                        break;
                }

                return error;
            }
        }

        public AbsenceViewModel()
        {
            SubjectList =
                UnitOfWork.GroupSubjectsRepository.GetAllSubjectsNamesByGroupId();

            Absences = UnitOfWork.AbsenceRepository.GetAllByCurrentUser();
            AbsenceCount = UnitOfWork.AbsenceRepository.GetCountOfAbsencesByUser();

            AddAbsenceCommand = new AddAbsenceCommand(this);
            Date = DateTime.Today;
        }
    }
}