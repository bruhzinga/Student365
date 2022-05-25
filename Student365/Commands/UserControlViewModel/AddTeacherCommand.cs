using Student365.Annotations;
using Student365.Models;
using Student365.Models.Repositories;
using Student365.ViewModels;

namespace Student365.Commands.UserControlViewModel
{
    public class AddTeacherCommand : CommandBase
    {
        private readonly TeacherControlView _teacherControlView;

        public AddTeacherCommand(TeacherControlView teacherControlView)
        {
            _teacherControlView = teacherControlView;
            _teacherControlView.PropertyChanged += _teacherControlView_PropertyChanged;
        }

        private void _teacherControlView_PropertyChanged(object sender,
            System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "NewUsername" || e.PropertyName == "NewName")
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            if (_teacherControlView["NewUsername"] != null || _teacherControlView["NewName"] != null)
            {
                return false;
            }

            return true;
        }

        public override void Execute(object parameter)
        {
            var teacher = new Teacher()
            {
                Username = _teacherControlView.NewUsername,
                Name = _teacherControlView.NewName
            };

            _teacherControlView.Teachers.Add(teacher);
            UnitOfWork.TeachersRepository.Add(teacher);
            TeacherControlView.Usernames.Remove(teacher.Username);
        }
    }
}