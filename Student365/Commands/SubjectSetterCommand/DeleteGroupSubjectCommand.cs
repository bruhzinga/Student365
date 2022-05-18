using System;
using Student365.Models.Repositories;
using Student365.ViewModels;

namespace Student365.Commands.SubjectSetterCommand
{
    public class DeleteGroupSubjectCommand : CommandBase
    {
        private readonly SubjectSetterViewModel _subjectSetterViewModel;

        public override void Execute(object parameter)
        {
            UnitOfWork.GroupSubjectsRepository.Remove(_subjectSetterViewModel.SelectedGroupSubject, Convert.ToInt32(_subjectSetterViewModel.Group));
            _subjectSetterViewModel.GroupSubjects.Remove(_subjectSetterViewModel.SelectedGroupSubject);
        }

        public DeleteGroupSubjectCommand(SubjectSetterViewModel subjectSetterViewModel)
        {
            _subjectSetterViewModel = subjectSetterViewModel;
        }
    }
}