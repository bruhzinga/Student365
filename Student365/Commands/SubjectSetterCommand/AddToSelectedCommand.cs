using System;
using System.Linq;
using Student365.Models.Repositories;
using Student365.ViewModels;

namespace Student365.Commands.SubjectSetterCommand
{
    public class AddToSelectedCommand : CommandBase
    {
        private readonly SubjectSetterViewModel _subjectSetterViewModel;

        public AddToSelectedCommand(SubjectSetterViewModel subjectSetterViewModel)
        {
            _subjectSetterViewModel = subjectSetterViewModel;
        }

        public override void Execute(object parameter)
        {
            UnitOfWork.GroupSubjectsRepository.AddToSelected(_subjectSetterViewModel.Subjects.Where(x => (bool)x.IsSelected).ToList(),
                Convert.ToInt16(_subjectSetterViewModel.Group));
        }
    }
}