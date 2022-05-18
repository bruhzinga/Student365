using System;
using System.Runtime.Serialization.Formatters;
using Student365.Models.Repositories;
using Student365.ViewModels;

namespace Student365.Commands.UserControlViewModel
{
    public class DeleteUserCommand : CommandBase
    {
        private readonly ViewModels.UserControlViewModel _userControlViewModel;

        public DeleteUserCommand(ViewModels.UserControlViewModel userControlViewModel)
        {
            _userControlViewModel = userControlViewModel;
            _userControlViewModel.PropertyChanged += _userControlViewModel_PropertyChanged;
        }

        private void _userControlViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedUser")
            {
                OnCanExecuteChanged();
            }
        }

        public override void Execute(object parameter)

        {
            StudentControlViewModel.Usernames.Remove(_userControlViewModel.Selected.UserName);
            UnitOfWork.UsersRepository.Remove(_userControlViewModel.Selected);
            _userControlViewModel.Users.Remove(_userControlViewModel.Selected);
        }

        public override bool CanExecute(object parameter)
        {
            if (_userControlViewModel.Selected == UnitOfWork.CurrentsUser)
                return false;
            return true;
        }
    }
}