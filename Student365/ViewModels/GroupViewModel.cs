using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student365.Models;
using Student365.Models.Repositories;

namespace Student365.ViewModels
{
    internal class GroupViewModel : BaseViewModel
    {
        private ObservableCollection<Student> _students;

        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged("Students");
            }
        }

        public GroupViewModel()
        {
            _students = UnitOfWork.StudentsRepository.GetGroup();
        }
    }
}