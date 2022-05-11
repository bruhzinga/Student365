using Student365.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student365.Models.Repositories;

namespace Student365.Commands
{
    internal class DeleteNoteCommand : CommandBase
    {
        private NoteViewModel noteViewModel;

        public DeleteNoteCommand(NoteViewModel noteViewModel)
        {
            this.noteViewModel = noteViewModel;
            this.noteViewModel.PropertyChanged += NoteViewModel_PropertyChanged;
        }

        private void NoteViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedNote")
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            if (noteViewModel.SelectedNote == null)
                return false;
            return true;
        }

        public override void Execute(object parameter)
        {
            var selected = noteViewModel.SelectedNote;

            UnitOfWork.NotesRepository.Delete(selected);
            noteViewModel.Notes = UnitOfWork.NotesRepository.GetAllNotesByUser(UnitOfWork.CurrentsUser.UserName);
            noteViewModel.SelectedNote = noteViewModel.Notes.FirstOrDefault();
        }
    }
}