using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MahApps.Metro.IconPacks;

using Student365.Models;
using Student365.Models.Repositories;

namespace Student365.ViewModels
{
    public class ScheduleViewModel : BaseViewModel
    {
        private ObservableCollection<Schedule> _schedule1_1;

        public ObservableCollection<Schedule> Schedule1_1
        {
            get => _schedule1_1;
            set
            {
                _schedule1_1 = value;
                OnPropertyChanged("Schedule1_1");
            }
        }

        private ObservableCollection<Schedule> _schedule1_2;

        public ObservableCollection<Schedule> Schedule1_2
        {
            get => _schedule1_2;
            set
            {
                _schedule1_2 = value;
                OnPropertyChanged("Schedule1_2");
            }
        }

        private ObservableCollection<Schedule> _schedule2_1;

        public ObservableCollection<Schedule> Schedule2_1
        {
            get => _schedule2_1;
            set
            {
                _schedule2_1 = value;
                OnPropertyChanged("Schedule2_1");
            }
        }

        private ObservableCollection<Schedule> _schedule2_2;

        public ObservableCollection<Schedule> Schedule2_2
        {
            get => _schedule2_2;
            set
            {
                _schedule2_2 = value;
                OnPropertyChanged("Schedule2_2");
            }
        }

        private ObservableCollection<Schedule> _schedule3_1;

        public ObservableCollection<Schedule> Schedule3_1
        {
            get => _schedule3_1;
            set
            {
                _schedule3_1 = value;
                OnPropertyChanged("Schedule3_1");
            }
        }

        private ObservableCollection<Schedule> _schedule3_2;

        public ObservableCollection<Schedule> Schedule3_2
        {
            get => _schedule3_2;
            set
            {
                _schedule3_2 = value;
                OnPropertyChanged("Schedule3_2");
            }
        }

        private ObservableCollection<Schedule> _schedule4_1;

        public ObservableCollection<Schedule> Schedule4_1
        {
            get => _schedule4_1;
            set
            {
                _schedule4_1 = value;
                OnPropertyChanged("Schedule4_1");
            }
        }

        private ObservableCollection<Schedule> _schedul4_2;
        public ObservableCollection<Schedule> Schedule4_2 { get; set; }

        private ObservableCollection<Schedule> _schedule5_1;

        public ObservableCollection<Schedule> Schedule5_1
        {
            get => _schedule5_1;
            set
            {
                _schedule5_1 = value;
                OnPropertyChanged("Schedule5_1");
            }
        }

        private ObservableCollection<Schedule> _schedule5_2;

        public ObservableCollection<Schedule> Schedule5_2
        {
            get => _schedule5_2;
            set
            {
                _schedule5_2 = value;
                OnPropertyChanged("Schedule5_2");
            }
        }

        private ObservableCollection<Schedule> _schedule6_1;

        public ObservableCollection<Schedule> Schedule6_1
        {
            get => _schedule6_1;
            set
            {
                _schedule6_1 = value;
                OnPropertyChanged("Schedule6_1");
            }
        }

        private ObservableCollection<Schedule> _schedule6_2;

        public ObservableCollection<Schedule> Schedule6_2
        {
            get => _schedule6_2;
            set
            {
                _schedule6_2 = value;
                OnPropertyChanged("Schedule6_2");
            }
        }

        public ScheduleViewModel()
        {
            SetAll();
        }

        public void SetAll()
        {
            _schedule1_1 = UnitOfWork.ScheduleRepository.GetByDayAndWeek(1, 1);
            _schedule1_2 = UnitOfWork.ScheduleRepository.GetByDayAndWeek(1, 2);
            _schedule2_1 = UnitOfWork.ScheduleRepository.GetByDayAndWeek(2, 1);
            _schedule2_2 = UnitOfWork.ScheduleRepository.GetByDayAndWeek(2, 2);
            _schedule3_1 = UnitOfWork.ScheduleRepository.GetByDayAndWeek(3, 1);
            _schedule3_2 = UnitOfWork.ScheduleRepository.GetByDayAndWeek(3, 2);
            _schedule4_1 = UnitOfWork.ScheduleRepository.GetByDayAndWeek(4, 1);
            _schedul4_2 = UnitOfWork.ScheduleRepository.GetByDayAndWeek(4, 2);
            _schedule5_1 = UnitOfWork.ScheduleRepository.GetByDayAndWeek(5, 1);
            _schedule5_2 = UnitOfWork.ScheduleRepository.GetByDayAndWeek(5, 2);
            _schedule6_1 = UnitOfWork.ScheduleRepository.GetByDayAndWeek(6, 1);
            _schedule6_2 = UnitOfWork.ScheduleRepository.GetByDayAndWeek(6, 2);
        }
    }
}