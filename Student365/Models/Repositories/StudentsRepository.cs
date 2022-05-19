using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student365.Models.Repositories
{
    internal class StudentsRepository : IGenericRepository<Student>

    {
        private DbContext _context = new Student365Entities();
        private DbSet<Student> _dbSet;

        public StudentsRepository()
        {
            _dbSet = _context.Set<Student>();
        }

        public void Create(Student item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public Student FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<Student> Get()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<Student> Get(Func<Student, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public void Remove(Student item)
        {
            _dbSet.Remove(item);
        }

        public void Update(Student item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public ObservableCollection<Student> GetGroup()
        {
            var group = GetCurrentUserGroup();
            return new ObservableCollection<Student>(_dbSet.Where(x => x.Group == group).ToList());
        }

        public int GetCurrentUserGroup()
        {
            return _dbSet.Where(x => x.UserName == UnitOfWork.CurrentsUser.UserName).Select(x => x.Group)
                .FirstOrDefault();
        }

        public int GetCurrentUserSubGroup()
        {
            return _dbSet.Where(x => x.UserName == UnitOfWork.CurrentsUser.UserName).Select(x => x.SubGroup)
                .FirstOrDefault();
        }

        public ObservableCollection<Student> GetAllStudents()
        {
            return new ObservableCollection<Student>(_dbSet.ToList());
        }

        public List<Student> GetAllStudentsByGroupId(int groupid)
        {
            return _dbSet.Where(x => x.Group == groupid).ToList();
        }
    }
}