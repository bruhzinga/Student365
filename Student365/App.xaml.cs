using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Student365.Stores;
using Student365.ViewModels;

namespace Student365
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static NavigationStore navigationStore;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = new LoginWindow()
            {
                DataContext = new LoginViewModel()
            };
            ShutdownMode = ShutdownMode.OnLastWindowClose;
            MainWindow.Show();
        }

        public App()
        {
            navigationStore = new NavigationStore();
        }
    }
}