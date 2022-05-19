using Student365.Models.Repositories;
using Student365.ViewModels;

namespace Student365.Commands.SubjectSetterCommand
{
    public class ChangeMaxLabsCommand : CommandBase

    {
        private readonly SubjectSetterViewModel _subjectSetterViewModel;

        public ChangeMaxLabsCommand(SubjectSetterViewModel subjectSetterViewModel)
        {
            _subjectSetterViewModel = subjectSetterViewModel;
        }

        public override void Execute(object parameter)
        {
            UnitOfWork.GroupSubjectsRepository.AddOrUpdateAll(_subjectSetterViewModel.GroupSubjects);
        }
    }
}