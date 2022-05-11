using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student365.Models.Repositories
{
    internal class NoteRepository
    {
        private DbContext _context = new DataBaseContext();
        private DbSet<Note> _dbSet;

        public NoteRepository()
        {
            _dbSet = _context.Set<Note>();
        }

        public ObservableCollection<Note> GetAllNotesByUser(string UserName)
        {
            var notes = _dbSet.Where(n => n.Username == UserName).ToList();
            return new ObservableCollection<Note>(notes);
        }

        public void Update()
        {
            _context.SaveChanges();
        }

        public void Create(Note note)
        {
            _dbSet.Add(note);
            _context.SaveChanges();
        }

        public void AddNote(string newNoteHeader)
        {
            Create(new Note()
            {
                Header = newNoteHeader,
                Text = string.Empty,
                Username = UnitOfWork.CurrentsUser.UserName
            });
            Update();
        }

        public void Delete(Note selected)
        {
            _dbSet.Remove(selected);
            Update();
        }
    }
}