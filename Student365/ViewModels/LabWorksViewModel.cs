using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Student365.Commands.LabWorksCommands;
using Student365.Models;
using Student365.Models.Repositories;

namespace Student365.ViewModels
{
    internal class LabWorksViewModel : BaseViewModel
    {
        private ObservableCollection<LabWork> _labWorks;

        public ObservableCollection<LabWork> LabWorks
        {
            get { return _labWorks; }
            set
            {
                _labWorks = value;
                OnPropertyChanged("LabWorks");
            }
        }

        private LabWork _SelectedItem;

        public LabWork SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public ICommand PlusCommand { get; }

        public ICommand MinusCommand { get; }

        public LabWorksViewModel()
        {
            LabWorks = UnitOfWork.LabWorksRepository.GetAllLabWorks();
            PlusCommand = new PlusCommand(this);
            MinusCommand = new MinusCommand(this);
            _SelectedItem = LabWorks.FirstOrDefault();
        }
    }
}