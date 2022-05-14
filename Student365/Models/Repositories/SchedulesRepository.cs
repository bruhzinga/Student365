using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student365.Models.Repositories
{
    internal class SchedulesRepository
    {
        private DbContext _context = new DataBaseContext();
        private DbSet<Schedule> _dbSet;

        public SchedulesRepository()
        {
            _dbSet = _context.Set<Schedule>();
        }

        public ObservableCollection<Schedule> GetByDayAndWeek(int day, int week)
        {
            var group = UnitOfWork.StudentsRepository.GetCurrentUserGroup();
            var subGroup = UnitOfWork.StudentsRepository.GetCurrentUserSubGroup();

            return new ObservableCollection<Schedule>(_dbSet.Where(x =>
                x.Day == day && x.Week_Num == week && x.Group == group &&
                x.SubGroup == subGroup));
        }
    }
}