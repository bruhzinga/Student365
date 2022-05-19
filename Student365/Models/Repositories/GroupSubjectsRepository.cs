﻿using System;
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

        public ObservableCollection<GroupSubject> GetAllSubjectsByGroupId(int groupId)
        {
            return new ObservableCollection<GroupSubject>(_dbSet_Gr.Where(x => x.Group == groupId));
        }

        public void Remove(Subject selectedSubject)
        {
            _dbSet_Sub.Remove(selectedSubject);
            _context.SaveChanges();
        }

        public ObservableCollection<Subject> GetAllSubjects()

        {
            var All = _dbSet_Sub.ToList();
            foreach (var subject in All)
            {
                subject.IsSelected = false;
                _dbSet_Sub.AddOrUpdate(subject);
            }
            _context.SaveChanges();
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

        public void AddOrUpdateAll(ObservableCollection<GroupSubject> subjects)
        {
            foreach (var subject in subjects)
            {
                _dbSet_Gr.AddOrUpdate(subject);
                if (subject.Max_Labs != null)
                {
                    UnitOfWork.LabWorksRepository.AddLabInfo(subject);
                }
            }
            _context.SaveChanges();
        }

        public void AddToSelected(List<Subject> subjects, short group)
        {
            var current = _dbSet_Gr.Where(x => x.Group == group).ToList();
            foreach (var subject in subjects)
            {
                if (!current.Any(x => x.Subject == subject.Name))
                {
                    _dbSet_Gr.Add(new GroupSubject() { Group = group, Subject = subject.Name });
                }
            }

            _context.SaveChanges();
        }

        public void Remove(GroupSubject selected)
        {
            var subject = selected.Subject;
            _dbSet_Gr.Remove(selected);
            UnitOfWork.LabWorksRepository.RemoveLabInfo(selected, subject);
            _context.SaveChanges();
        }

        public ObservableCollection<string> GetAllSubjectsNamesByGroupId(int getCurrentUserGroup)
        {
            return new ObservableCollection<string>(_dbSet_Gr.Where(x => x.Group == getCurrentUserGroup).Select(x => x.Subject));
        }
    }
}