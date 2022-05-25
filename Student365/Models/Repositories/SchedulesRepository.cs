using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Student365.Models.Repositories
{
    internal class SchedulesRepository
    {
        private DbContext _context = new Student365Entities();
        private DbSet<Schedule> _dbSet;

        public SchedulesRepository()
        {
            _dbSet = _context.Set<Schedule>();
        }

        public ObservableCollection<Schedule> GetByDayAndWeek(int day, int week)
        {
            var group = UnitOfWork.StudentsRepository.GetCurrentUserGroup();
            var subGroup = UnitOfWork.StudentsRepository.GetCurrentUserSubGroup();
            var Kurs = UnitOfWork.StudentsRepository.GetCurrentUserKurs();

            return new ObservableCollection<Schedule>(_dbSet.Where(x =>
                x.Day == day && x.Week_Num == week && x.Group == group &&
                x.SubGroup == subGroup && x.Kurs == Kurs).ToList());
        }

        public ObservableCollection<Schedule> GetByDayAndWeek(int day, int week, int group, int subgroup, int kurs)
        {
            var col = new ObservableCollection<Schedule>(_dbSet.Where(x =>
                x.Day == day && x.Week_Num == week && x.Group == group &&
                x.SubGroup == subgroup && x.Kurs == kurs));
            if (col.Count == 0)
            {
                for (int i = 1; i <= 6; i++)
                {
                    for (byte w = 1; w <= 2; w++)
                    {
                        for (byte j = 1; j <= 4; j++)
                        {
                            var schedule = new Schedule()
                            {
                                Kurs = (byte?)kurs,
                                Group = (short)group,
                                SubGroup = (short)subgroup,
                                Day = (byte)i,
                                Week_Num = w,
                                Subject_Num = j
                            };
                            _dbSet.Add(schedule);
                            Update();
                        }
                    }
                }
            }

            return new ObservableCollection<Schedule>(_dbSet.Where(x =>
                x.Day == day && x.Week_Num == week && x.Group == group &&
                x.SubGroup == subgroup && x.Kurs == kurs)); ;
        }

        public void Update()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}