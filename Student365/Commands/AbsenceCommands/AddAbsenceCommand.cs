using System.Runtime.InteropServices;
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
            _absenceViewModel.PropertyChanged += AbsenceViewModel_PropertyChanged;
        }

        private void AbsenceViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Selected" || e.PropertyName == "Reason")
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            if (_absenceViewModel["Selected"] != null || _absenceViewModel["Reason"] != null)
            {
                return false;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            UnitOfWork.AbsenceRepository.Add(_absenceViewModel.Date, _absenceViewModel.Reason, _absenceViewModel.Selected);
            _absenceViewModel.Absences = UnitOfWork.AbsenceRepository.GetAllByCurrentUser();
            _absenceViewModel.AbsenceCount = UnitOfWork.AbsenceRepository.GetCountOfAbsencesByUser();
        }
    }
}