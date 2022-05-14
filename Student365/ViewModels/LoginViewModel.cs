using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Student365.Commands;

namespace Student365.ViewModels
{
    public class LoginViewModel : BaseViewModel

    {
        private string _username;

        public string Username
        {
            get
            {
                if (_username == null)
                    return "Admin";
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;

        public string Password
        {
            get
            {
                if (_password == null)
                {
                    return "Admin";
                }
                else
                {
                    return _password;
                }
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand ExitCommand { get; }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            ExitCommand = new ExitCommand();
            LoginCommand = new LoginCommand(this);
        }
    }
}