using System.Linq;
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
            var delete = _subjectSetterViewModel.Subjects.Where(x => string.IsNullOrEmpty(x.Name)).ToList();
            foreach (var subject in delete)
            {
                _subjectSetterViewModel.Subjects.Remove(subject);
            }
            UnitOfWork.GroupSubjectsRepository.AddOrUpdateAll(_subjectSetterViewModel.Subjects);
        }
    }
}