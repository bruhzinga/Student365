using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student365.Models.Repositories;
using Student365.ViewModels;

namespace Student365.Commands
{
    internal class AddNoteCommand : CommandBase
    {
        public NoteViewModel NoteViewModel { get; }

        public AddNoteCommand(NoteViewModel noteViewModel)
        {
            NoteViewModel = noteViewModel;
        }

        public override void Execute(object parameter)
        {
            UnitOfWork.NotesRepository.AddNote(NoteViewModel.NewNoteHeader);
            NoteViewModel.Notes = UnitOfWork.NotesRepository.GetAllNotesByUser(UnitOfWork.CurrentsUser.UserName);
        }
    }
}