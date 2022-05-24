using System;
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
            _gradeViewModel.PropertyChanged += _gradeViewModel_PropertyChanged;
        }

        private void _gradeViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Grade" || e.PropertyName == "NewSubject")
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            if (_gradeViewModel["Grade"] != null)
                return false;
            if (_gradeViewModel["NewSubject"] != null)
                return false;
            return true;
        }

        public override void Execute(object parameter)
        {
            var grade = new Grade()
            {
                grade1 = Convert.ToInt16(_gradeViewModel.Grade),
                subject = _gradeViewModel.NewSubject,
                username = UnitOfWork.CurrentsUser.UserName
            };
            UnitOfWork.GradeRepository.Add(grade);
            _gradeViewModel.GetSubjects();
        }
    }
}