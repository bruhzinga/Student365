using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student365.Models.Repositories
{
    internal class AbsenceRepository
    {
        private DbContext _context = new DataBaseContext();
        private DbSet<Absence> _dbSet;

        public AbsenceRepository()
        {
            _dbSet = _context.Set<Absence>();
        }

        public ObservableCollection<Absence> GetAllByCurrentUser()
        {
            return new ObservableCollection<Absence>(_dbSet.Where(x => x.Username == UnitOfWork.CurrentsUser.UserName));
        }

        public void Update()
        {
            _context.SaveChanges();
        }

        public void Add(DateTime date, string reason, string subject)
        {
            _dbSet.Add(new Absence() { Date = date, Reason = reason, Subject = subject, Username = UnitOfWork.CurrentsUser.UserName });
            Update();
        }

        public Dictionary<string, int> GetCountOfAbsencesByUser()
        {
            var query = _dbSet
                .Where(x => x.Username == UnitOfWork.CurrentsUser.UserName)
                .GroupBy(p => p.Subject)
                .Select(g => new { name = g.Key, count = g.Count() }).ToDictionary(k => k.name, i => i.count);
            return query;
        }
    }
}