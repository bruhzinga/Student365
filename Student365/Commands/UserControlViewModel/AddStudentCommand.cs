using System;
using Student365.Models;
using Student365.Models.Repositories;
using Student365.ViewModels;

namespace Student365.Commands.UserControlViewModel
{
    public class AddStudentCommand : CommandBase
    {
        private readonly StudentControlViewModel _studentControlViewModel;

        public AddStudentCommand(StudentControlViewModel studentControlViewModel)
        {
            _studentControlViewModel = studentControlViewModel;
        }

        public override void Execute(object parameter)
        {
            var Student = new Student()
            {
                UserName = _studentControlViewModel.NewUsername,
                Group = Convert.ToInt16(_studentControlViewModel.NewGroup),
                Name = _studentControlViewModel.NewName,
                Kurs = Convert.ToInt32(_studentControlViewModel.NewKurs),
                SubGroup = Convert.ToInt16(_studentControlViewModel.NewSubgroup),
                Phone = _studentControlViewModel.NewPhone
            };
            UnitOfWork.StudentsRepository.Create(Student);
            _studentControlViewModel.Students.Add(Student);
        }
    }
}