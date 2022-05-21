using Student365.Models;
using Student365.Models.Repositories;
using Student365.ViewModels;

namespace Student365.Commands.GradeControlVIewModel
{
    public class AddGradeCommand : CommandBase
    {
        private readonly GradeViewModel _gradeViewModel;

        public AddGradeCommand(GradeViewModel gradeViewModel)
        {
            _gradeViewModel = gradeViewModel;
        }

        public override void Execute(object parameter)
        {
            var grade = new Grade()
            {
                grade1 = _gradeViewModel.Grade,
                subject = _gradeViewModel.NewSubject,
                username = UnitOfWork.CurrentsUser.UserName
            };
            UnitOfWork.GradeRepository.Add(grade);
            _gradeViewModel.GetSubjects();
        }
    }
}