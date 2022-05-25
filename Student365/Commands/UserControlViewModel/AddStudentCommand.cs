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
            _studentControlViewModel.PropertyChanged += _studentControlViewModel_PropertyChanged;
        }

        private void _studentControlViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "NewUsername" || e.PropertyName == "NewName" || e.PropertyName == "NewGroup" || e.PropertyName == "NewKurs" || e.PropertyName == "NewSubgroup" || e.PropertyName == "NewPhone")
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            if (_studentControlViewModel["NewUsername"] != null || _studentControlViewModel["NewName"] != null || _studentControlViewModel["NewGroup"] != null || _studentControlViewModel["NewKurs"] != null || _studentControlViewModel["NewSubgroup"] != null || _studentControlViewModel["NewPhone"] != null)
            {
                return false;
            }

            return true;
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
            StudentControlViewModel.Usernames.Remove(Student.UserName);
            _studentControlViewModel.NewUsername = string.Empty;
        }
    }
}