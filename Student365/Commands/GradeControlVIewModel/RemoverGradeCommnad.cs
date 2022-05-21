using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student365.Models.Repositories;
using Student365.ViewModels;

namespace Student365.Commands.GradeControlVIewModel
{
    internal class RemoverGradeCommnad : CommandBase

    {
        private readonly GradeViewModel _gradeViewModel;

        public RemoverGradeCommnad(GradeViewModel gradeViewModel)
        {
            _gradeViewModel = gradeViewModel;
        }

        public override void Execute(object parameter)
        {
            var key = (int)(parameter);
            UnitOfWork.GradeRepository.removebyid(key);
            _gradeViewModel.GetSubjects();
        }
    }
}