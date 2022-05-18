using Student365.Models.Repositories;
using Student365.ViewModels;

namespace Student365.Commands.UserControlViewModel
{
    public class DeleteStudentCommand : CommandBase
    {
        private readonly StudentControlViewModel _studentControlViewModel;

        public DeleteStudentCommand(StudentControlViewModel studentControlViewModel)
        {
            _studentControlViewModel = studentControlViewModel;
        }

        public override void Execute(object parameter)
        {
            UnitOfWork.StudentsRepository.Remove(_studentControlViewModel.Selected_Student);
            _studentControlViewModel.Students.Remove(_studentControlViewModel.Selected_Student);
        }
    }
}