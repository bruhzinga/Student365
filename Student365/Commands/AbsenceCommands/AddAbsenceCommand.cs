using Student365.Models.Repositories;
using Student365.ViewModels;

namespace Student365.Commands.AbsenceCommands
{
    public class AddAbsenceCommand : CommandBase
    {
        private readonly AbsenceViewModel _absenceViewModel;

        public AddAbsenceCommand(AbsenceViewModel absenceViewModel)
        {
            _absenceViewModel = absenceViewModel;
        }

        public override void Execute(object parameter)
        {
            UnitOfWork.AbsenceRepository.Add(_absenceViewModel.Date, _absenceViewModel.Reason, _absenceViewModel.Selected);
            _absenceViewModel.Absences = UnitOfWork.AbsenceRepository.GetAllByCurrentUser();
            _absenceViewModel.AbsenceCount = UnitOfWork.AbsenceRepository.GetCountOfAbsencesByUser();
        }
    }
}