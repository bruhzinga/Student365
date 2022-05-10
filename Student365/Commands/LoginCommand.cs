using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Student365.Models;
using Student365.Models.Repositories;
using Student365.ViewModels;

namespace Student365.Commands
{
    internal class LoginCommand : CommandBase
    {
        private LoginViewModel _viewModel;

        public override void Execute(object? parameter)
        {
            var users = UnitOfWork.UsersRepository;

            var user = users.GetUser(_viewModel.Username, _viewModel.Password);
            if (user == null)
            {
                MessageBox.Show("BRUH");
            }
            else
            {
                UnitOfWork.CurrentsUser = (User)user;
                var sw = new MainWindow();
                Application.Current.MainWindow.Close();
                sw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                App.navigationStore.CurrentViewModel = new ScheduleViewModel();
                sw.DataContext = new MainViewModel(App.navigationStore);
                sw.View.DataContext = new MainViewModel(App.navigationStore);
                System.Windows.Application.Current.MainWindow = sw;
                sw.Show();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            if (string.IsNullOrEmpty(_viewModel.Username) || string.IsNullOrEmpty(_viewModel.Password))
                return false;
            return true;
        }

        public LoginCommand(LoginViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public void OnViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.Username) || e.PropertyName == nameof(_viewModel.Password))
                OnCanExecuteChanged();
        }
    }
}