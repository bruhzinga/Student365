using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Student365.Models;
using Student365.Models.Repositories;
using Student365.ViewModels;

namespace Student365.Commands.LabWorksCommands
{
    internal class PlusCommand : CommandBase
    {
        private readonly LabWorksViewModel _labWorksViewModel;

        public PlusCommand(LabWorksViewModel labWorksViewModel)
        {
            _labWorksViewModel = labWorksViewModel;
            _labWorksViewModel.PropertyChanged += _labWorksViewModel_PropertyChanged;
        }

        private void _labWorksViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedItem")
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            if (_labWorksViewModel.SelectedItem == null)
            {
                return false;
            }

            if (_labWorksViewModel.SelectedItem.Current_amount_of_Labs >= _labWorksViewModel.SelectedItem.Max_amount_of_Labs)
            {
                return false;
            }

            return true;
        }

        public override void Execute(object parameter)
        {
            _labWorksViewModel.SelectedItem.Current_amount_of_Labs++;
            UnitOfWork.LabWorksRepository.Update();
            var temp = new ObservableCollection<LabWork>(_labWorksViewModel.LabWorks);
            _labWorksViewModel.LabWorks = temp;
        }
    }
}