using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Student365.Models.Repositories
{
    public class GroupSubjectsRepository
    {
        private DbContext _context = new Student365Entities();
        private DbSet<GroupSubject> _dbSet_Gr;
        private DbSet<Subject> _dbSet_Sub;

        public GroupSubjectsRepository()
        {
            _dbSet_Gr = _context.Set<GroupSubject>();
            _dbSet_Sub = _context.Set<Subject>();
        }

        public ObservableCollection<string> GetAllSubjectsNamesByGroupId(int groupId)
        {
            return new ObservableCollection<string>(_dbSet_Gr.Where(x => x.Group == groupId).Select(x => x.Subject));
        }

        public void Remove(Subject selectedSubject)
        {
            _dbSet_Sub.Remove(selectedSubject);
            _context.SaveChanges();
        }

        public ObservableCollection<Subject> GetAllSubjects()
        {
            return new ObservableCollection<Subject>(_dbSet_Sub.ToList());
        }

        public void AddOrUpdateAll(ObservableCollection<Subject> subjects)
        {
            foreach (var subject in subjects)
            {
                _dbSet_Sub.AddOrUpdate(subject);
            }
            _context.SaveChanges();
        }

        public void AddToSelected(List<Subject> subjects, short group)
        {
            foreach (var subject in subjects)
            {
                _dbSet_Gr.AddOrUpdate(new GroupSubject { Group = group, Subject = subject.Name });
            }
            _context.SaveChanges();
        }

        public void Remove(string selected, int groupId)
        {
            _dbSet_Gr.Remove(_dbSet_Gr.FirstOrDefault(x => x.Subject == selected && x.Group == groupId));
            _context.SaveChanges();
        }
    }
}