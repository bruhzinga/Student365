using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student365.Models;
using Student365.Models.Repositories;

namespace Student365.ViewModels
{
    public class ScheduleViewModel : BaseViewModel
    {
        private ObservableCollection<Schedule> _firstSchedule;

        public ObservableCollection<Schedule> FirstSchedule
        {
            get => _firstSchedule;
            set
            {
                _firstSchedule = value;
                OnPropertyChanged(nameof(FirstSchedule));
            }
        }

        private ObservableCollection<Schedule> _secondSchedule;

        public ObservableCollection<Schedule> SecondSchedule
        {
            get => _secondSchedule;
            set
            {
                _firstSchedule = value;
                OnPropertyChanged(nameof(SecondSchedule));
            }
        }

        private ObservableCollection<Schedule> _thirdSchedule;

        public ObservableCollection<Schedule> ThirdSchedule
        {
            get => _thirdSchedule;
            set
            {
                _thirdSchedule = value;
                OnPropertyChanged(nameof(ThirdSchedule));
            }
        }

        private ObservableCollection<Schedule> _fourhShedule;

        public ObservableCollection<Schedule> FourthSchedule
        {
            get => _fourhShedule;
            set
            {
                _thirdSchedule = value;
                OnPropertyChanged(nameof(FourthSchedule));
            }
        }

        private ObservableCollection<Schedule> _fifthShedule;

        public ObservableCollection<Schedule> FifthSchedule
        {
            get => _fourhShedule;
            set
            {
                _thirdSchedule = value;
                OnPropertyChanged(nameof(FifthSchedule));
            }
        }

        private ObservableCollection<Schedule> _SixthShedule;

        public ObservableCollection<Schedule> SixthhSchedule
        {
            get => _SixthShedule;
            set
            {
                _thirdSchedule = value;
                OnPropertyChanged(nameof(SixthhSchedule));
            }
        }

        public ScheduleViewModel()
        {
            _firstSchedule = UnitOfWork.ScheduleRepository.GetByDay(1);
            _secondSchedule = UnitOfWork.ScheduleRepository.GetByDay(2);
            _thirdSchedule = UnitOfWork.ScheduleRepository.GetByDay(3);
            _fourhShedule = UnitOfWork.ScheduleRepository.GetByDay(4);
            _fifthShedule = UnitOfWork.ScheduleRepository.GetByDay(5);
            _SixthShedule = UnitOfWork.ScheduleRepository.GetByDay(6);
        }
    }
}