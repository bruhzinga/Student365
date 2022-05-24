using Student365.Models.Repositories;
using Student365.ViewModels;

namespace Student365.Commands.SubjectSetterCommand
{
    public class DeleteSubjectCommand : CommandBase
    {
        private readonly SubjectSetterViewModel _subjectSetterViewModel;

        public DeleteSubjectCommand(SubjectSetterViewModel subjectSetterViewModel)
        {
            _subjectSetterViewModel = subjectSetterViewModel;
        }

        public override void Execute(object parameter)
        {
            if (_subjectSetterViewModel.SelectedSubject is null)
            {
                return;
            }
            UnitOfWork.GroupSubjectsRepository.Remove(_subjectSetterViewModel.SelectedSubject);
            _subjectSetterViewModel.Subjects.Remove(_subjectSetterViewModel.SelectedSubject);
        }
    }
}