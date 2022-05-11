using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student365.Models;
using Student365.Models.Repositories;
using Student365.ViewModels;

namespace Student365.Commands
{
    internal class SubmitNoteCommand : CommandBase
    {
        private readonly NoteViewModel _noteViewModel;

        public SubmitNoteCommand(NoteViewModel noteViewModel)
        {
            _noteViewModel = noteViewModel;
        }

        public override void Execute(object parameter)
        {
            var selected = _noteViewModel.SelectedNote;
            selected.Text = _noteViewModel.Text;
            selected.Header = _noteViewModel.SelectedName;
            UnitOfWork.NotesRepository.Update();
            _noteViewModel.Notes = UnitOfWork.NotesRepository.GetAllNotesByUser(UnitOfWork.CurrentsUser.UserName);
        }
    }
}