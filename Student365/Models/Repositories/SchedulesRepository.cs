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

        public ObservableCollection<Schedule> GetByDay(int i)
        {
            var group = UnitOfWork.StudentsRepository.GetCurrentUserGroup();
            var subGroup = UnitOfWork.StudentsRepository.GetCurrentUserSubGroup();

            return new ObservableCollection<Schedule>(_dbSet.Where(x =>
                x.Day == i && x.Group == group &&
                x.SubGroup == subGroup));
        }
    }
}