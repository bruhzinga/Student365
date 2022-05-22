using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student365.Models.Repositories
{
    internal class LabWorksRepository
    {
        private DbContext _context = new Student365Entities();
        private DbSet<LabWork> _dbSet;

        public LabWorksRepository()
        {
            _dbSet = _context.Set<LabWork>();
        }

        public ObservableCollection<LabWork> GetAllLabWorks()
        {
            return new ObservableCollection<LabWork>(_dbSet.Where(x => x.Username == UnitOfWork.CurrentsUser.UserName));
        }

        public void Update()
        {
            _context.SaveChanges();
        }

        public void AddLabInfo(GroupSubject subject)
        {
            var usernames = UnitOfWork.StudentsRepository.GetAllStudentsByGroupId((int)subject.Group, (short)subject.Kurs).Select(x => x.UserName).ToList();
            var labWorks = _dbSet.Where(x => usernames.Contains(x.Username) && x.Subject == subject.Subject).ToList();

            foreach (var username in usernames)
            {
                if (!labWorks.Select(x => x.Subject).Contains(subject.Subject))
                {
                    var labWork = new LabWork
                    {
                        Username = username,
                        Subject = subject.Subject,
                        Current_amount_of_Labs = 0,
                        Max_amount_of_Labs = subject.Max_Labs,
                    };

                    _dbSet.Add(labWork);
                    _context.SaveChanges();
                }
                else
                {
                    var affected = labWorks.Where(x => x.Subject == subject.Subject).ToList();
                    foreach (var labWork in affected)
                    {
                        labWork.Max_amount_of_Labs = subject.Max_Labs;
                        _context.SaveChanges();
                    }
                }
            }
        }

        public void RemoveLabInfo(GroupSubject selected, string subject)
        {
            var usernames = UnitOfWork.StudentsRepository.GetAllStudentsByGroupId((int)selected.Group, (short)selected.Kurs).Select(x => x.UserName).ToList();
            var labWorks = _dbSet.Where(x => usernames.Contains(x.Username) && x.Subject == subject).ToList();

            foreach (var labWork in labWorks)
            {
                _dbSet.Remove(labWork);
            }

            _context.SaveChanges();
        }
    }
}