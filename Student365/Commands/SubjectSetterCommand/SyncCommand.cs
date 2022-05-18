using Student365.Models.Repositories;
using Student365.ViewModels;

namespace Student365.Commands.SubjectSetterCommand
{
    public class SyncCommand : CommandBase
    {
        private readonly SubjectSetterViewModel _subjectSetterViewModel;

        public SyncCommand(SubjectSetterViewModel subjectSetterViewModel)
        {
            _subjectSetterViewModel = subjectSetterViewModel;
        }

        public override void Execute(object parameter)
        {
            UnitOfWork.GroupSubjectsRepository.AddOrUpdateAll(_subjectSetterViewModel.Subjects);
        }
    }
}