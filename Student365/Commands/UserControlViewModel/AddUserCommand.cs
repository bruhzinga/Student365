using System.Linq;
using Student365.Models;
using Student365.Models.Repositories;
using Student365.ViewModels;

namespace Student365.Commands.UserControlViewModel
{
    public class AddUserCommand : CommandBase
    {
        private readonly ViewModels.UserControlViewModel _userControlViewModel;

        public AddUserCommand(ViewModels.UserControlViewModel userControlViewModel)
        {
            _userControlViewModel = userControlViewModel;
            _userControlViewModel.PropertyChanged += _userControlViewModel_PropertyChanged;
        }

        private void _userControlViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "NewUsername" || e.PropertyName == "NewPassword" || e.PropertyName == "NewRole")
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            if (_userControlViewModel["NewUsername"] != null || _userControlViewModel["NewPassword"] != null || _userControlViewModel["NewRole"] != null)
            {
                return false;
            }

            return true;
        }

        public override void Execute(object parameter)
        {
            var user = new User()
            {
                UserName = _userControlViewModel.NewUsername,
                Password = _userControlViewModel.NewPassword,
                Role = _userControlViewModel.NewRole
            };

            UnitOfWork.UsersRepository.AddOrUpdate(user);
            if (!_userControlViewModel.Users.Select(x => x.UserName).Contains(user.UserName))
                _userControlViewModel.Users.Add(user);
            StudentControlViewModel.Usernames.Add(user.UserName);
        }
    }
}