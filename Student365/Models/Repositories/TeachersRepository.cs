using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using Student365.Models;

namespace Student365.ViewModels
{
    public class TeachersRepository
    {
        private DbContext _context = new Student365Entities();
        private DbSet<Teacher> _dbSet;

        public TeachersRepository()
        {
            _dbSet = _context.Set<Teacher>();
        }

        public ObservableCollection<Teacher> GetAll()
        {
            return new ObservableCollection<Teacher>(_dbSet.ToList());
        }

        public void Add(Teacher teacher)
        {
            _dbSet.Add(teacher);
            _context.SaveChanges();
        }

        public void Remove(Teacher selected)
        {
            _dbSet.Remove(selected);
            _context.SaveChanges();
        }
    }
}