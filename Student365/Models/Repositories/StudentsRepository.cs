﻿using System;
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
        private DbContext _context = new DataBaseContext();
        private DbSet<Student> _dbSet;

        public StudentsRepository()
        {
            _dbSet = _context.Set<Student>();
        }

        public void Create(Student item)
        {
            _dbSet.Add(item);
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
    }
}