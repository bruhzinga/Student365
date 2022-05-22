using System.Collections.ObjectModel;
using System.Dynamic;
using System.IO.Ports;
using System.Linq;
using System.Text.RegularExpressions;
using Student365.Models;
using Student365.Models.Repositories;

namespace Student365.ViewModels
{
    public class ScheduleSetterViewModel : BaseViewModel
    {
        #region COLLECTIONS

        private ObservableCollection<Schedule> _monday;

        public ObservableCollection<Schedule> Monday
        {
            get => _monday;
            set
            {
                _monday = value;
                OnPropertyChanged();
                UnitOfWork.ScheduleRepository.Update();
            }
        }

        private ObservableCollection<Schedule> _tuesday;

        public ObservableCollection<Schedule> Tuesday
        {
            get => _tuesday;
            set
            {
                _tuesday = value;
                OnPropertyChanged();
                UnitOfWork.ScheduleRepository.Update();
            }
        }

        private ObservableCollection<Schedule> _wednesday;

        public ObservableCollection<Schedule> Wednesday
        {
            get => _wednesday;
            set
            {
                _wednesday = value;
                OnPropertyChanged();
                UnitOfWork.ScheduleRepository.Update();
            }
        }

        private ObservableCollection<Schedule> _thursday;

        public ObservableCollection<Schedule> Thursday
        {
            get => _thursday;
            set
            {
                _thursday = value;
                OnPropertyChanged();
                UnitOfWork.ScheduleRepository.Update();
            }
        }

        private ObservableCollection<Schedule> _friday;

        public ObservableCollection<Schedule> Friday
        {
            get => _friday;
            set
            {
                _friday = value;
                OnPropertyChanged();
                UnitOfWork.ScheduleRepository.Update();
            }
        }

        private ObservableCollection<Schedule> _saturday;

        public ObservableCollection<Schedule> Saturday
        {
            get => _saturday;
            set
            {
                _saturday = value;
                OnPropertyChanged();
                UnitOfWork.ScheduleRepository.Update();
            }
        }

        #endregion COLLECTIONS

        private short _group;
        private short _subgroup;
        private short _kurs;

        public short Group
        {
            get => _group;
            set
            {
                _group = value;
                SetDays(Group, Subgroup, !IsChecked ? (short)2 : (short)1, Kurs);
                Subjects = new ObservableCollection<string>(UnitOfWork.GroupSubjectsRepository
                    .GetAllSubjectsByGroupId(Group, Kurs).Select(x => x.Subject).ToList());
                OnPropertyChanged();
            }
        }

        public short Subgroup
        {
            get => _subgroup;
            set
            {
                _subgroup = value;
                SetDays(Group, Subgroup, !IsChecked ? (short)2 : (short)1, Kurs);
                OnPropertyChanged();
            }
        }

        public short Kurs
        {
            get => _kurs;
            set
            {
                _kurs = value;
                SetDays(Group, Subgroup, IsChecked ? (short)2 : (short)1, Kurs);
                Subjects = new ObservableCollection<string>(UnitOfWork.GroupSubjectsRepository
                    .GetAllSubjectsByGroupId(Group, Kurs).Select(x => x.Subject).ToList());
                OnPropertyChanged();
            }
        }

        private bool _isChecked;

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                _isChecked = value;
                SetDays(Group, Subgroup, !IsChecked ? (short)2 : (short)1, Kurs);
                Subjects = new ObservableCollection<string>(UnitOfWork.GroupSubjectsRepository
                    .GetAllSubjectsByGroupId(Group, Kurs).Select(x => x.Subject).ToList());
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _subjects;

        public ObservableCollection<string> Subjects
        {
            get => _subjects;
            set
            {
                _subjects = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> Types { get; set; }

        public ScheduleSetterViewModel()
        {
            IsChecked = true;
            Group = 4;
            Subgroup = 1;
            Kurs = 2;
            SetDays(4, 1, 1, 2);
            Subjects = new ObservableCollection<string>(UnitOfWork.GroupSubjectsRepository
                .GetAllSubjectsByGroupId(Group, Kurs).Select(x => x.Subject).ToList());
            Types = new ObservableCollection<string>()
            {
                "ЛК", "ПЗ", "ЛР"
            };
        }

        public void SetDays(short group, short sub, short week, short kurs)
        {
            Monday = UnitOfWork.ScheduleRepository.GetByDayAndWeek(1, week, group, sub, kurs);

            Tuesday = UnitOfWork.ScheduleRepository.GetByDayAndWeek(2, week, group, sub, kurs);
            Wednesday = UnitOfWork.ScheduleRepository.GetByDayAndWeek(3, week, group, sub, kurs);
            Thursday = UnitOfWork.ScheduleRepository.GetByDayAndWeek(4, week, group, sub, kurs);
            Friday = UnitOfWork.ScheduleRepository.GetByDayAndWeek(5, week, group, sub, kurs);
            Saturday = UnitOfWork.ScheduleRepository.GetByDayAndWeek(6, week, group, sub, kurs);
        }
    }
}