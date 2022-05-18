using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
    }
}