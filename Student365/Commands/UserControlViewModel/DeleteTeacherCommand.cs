using Student365.Models.Repositories;
using Student365.ViewModels;

namespace Student365.Commands.UserControlViewModel
{
    public class DeleteTeacherCommand : CommandBase
    {
        private readonly TeacherControlView _teacherControlView;

        public DeleteTeacherCommand(TeacherControlView teacherControlView)
        {
            _teacherControlView = teacherControlView;
        }

        public override void Execute(object parameter)

        {
            TeacherControlView.Usernames.Add(_teacherControlView.Selected.Username);
            UnitOfWork.TeachersRepository.Remove(_teacherControlView.Selected);
            _teacherControlView.Teachers.Remove(_teacherControlView.Selected);
        }
    }
}