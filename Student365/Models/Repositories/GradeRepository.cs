using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace Student365.Models.Repositories
{
    public class GradeRepository
    {
        private DbContext _context = new Student365Entities();
        private DbSet<Grade> _dbSet;

        public GradeRepository()
        {
            _dbSet = _context.Set<Grade>();
        }

        public ObservableCollection<Grade> GetAllGradesByCurrentUser()
        {
            var grades = _dbSet.Where(x => x.User.UserName == UnitOfWork.CurrentsUser.UserName);
            return new ObservableCollection<Grade>(grades.ToList());
        }

        public void Add(Grade grade)
        {
            _dbSet.Add(grade);
            _context.SaveChanges();
        }

        public void removebyid(int key)
        {
            var grade = _dbSet.Find(key);
            _dbSet.Remove(grade);
            _context.SaveChanges();
        }
    }
}