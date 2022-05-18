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