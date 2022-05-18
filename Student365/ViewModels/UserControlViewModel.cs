using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Student365.Commands.UserControlViewModel;
using Student365.Models;
using Student365.Models.Repositories;

namespace Student365.ViewModels
{
    public class UserControlViewModel : BaseViewModel
    {
        private ObservableCollection<User> _users;

        public ObservableCollection<User> Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        private ObservableCollection<string> _roles;

        public ObservableCollection<string> Roles
        {
            get
            {
                return _roles;
            }
            set
            {
                _roles = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        private User _selected;

        public User Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                UnitOfWork.UsersRepository.Save();
                OnPropertyChanged(nameof(Selected));
            }
        }

        private string _newUserName;

        public string NewUsername
        {
            get
            {
                return _newUserName;
            }
            set
            {
                _newUserName = value;
                OnPropertyChanged(nameof(NewUsername));
            }
        }

        private string _newPassword;

        public string NewPassword
        {
            get
            {
                return _newPassword;
            }
            set
            {
                _newPassword = value;
                OnPropertyChanged(nameof(NewPassword));
            }
        }

        private string _newRole;

        public string NewRole
        {
            get
            {
                return _newRole;
            }
            set
            {
                _newRole = value;
                OnPropertyChanged(nameof(NewRole));
            }
        }

        public ICommand DeleteCommand { get; }
        public ICommand AddCommand { get; }

        public UserControlViewModel()
        {
            Users = UnitOfWork.UsersRepository.GetUsers();

            Roles = new ObservableCollection<string>()
            {
                "Admin",
                "User",
                "Teacher"
            };
            DeleteCommand = new DeleteUserCommand(this);
            AddCommand = new AddUserCommand(this);
        }
    }

    public class StudentControlViewModel : BaseViewModel
    {
        private ObservableCollection<Student> _students;

        public ObservableCollection<Student> Students
        {
            get
            {
                return _students;
            }
            set
            {
                _students = value;
                OnPropertyChanged(nameof(Students));
            }
        }

        public static ObservableCollection<string> Usernames
        {
            get
            {
                return _usernames;
            }
            set
            {
                _usernames = value;
            }
        }

        private static ObservableCollection<string> _usernames;

        private string _newName;

        public string NewName
        {
            get
            {
                return _newName;
            }
            set
            {
                _newName = value;
                OnPropertyChanged();
            }
        }

        private string _newUsername;

        public string NewUsername
        {
            get
            {
                return _newUsername;
            }
            set
            {
                _newUsername = value;
                OnPropertyChanged();
            }
        }

        private string _newGroup;

        public string NewGroup
        {
            get
            {
                return _newGroup;
            }
            set
            {
                _newGroup = value;
                OnPropertyChanged();
            }
        }

        private string _newSubgroup;

        public string NewSubgroup
        {
            get
            {
                return _newSubgroup;
            }
            set
            {
                _newSubgroup = value;
                OnPropertyChanged();
            }
        }

        private string _newKurs;

        public string NewKurs

        {
            get
            {
                return _newKurs;
            }

            set
            {
                _newKurs = value;
                OnPropertyChanged();
            }
        }

        private string _newPhone;

        public string NewPhone
        {
            get
            {
                return _newPhone;
            }

            set
            {
                _newPhone = value;
                OnPropertyChanged();
            }
        }

        private Student _selected;

        public Student Selected_Student
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                OnPropertyChanged();
            }
        }

        public ICommand DeleteCommand { get; }
        public ICommand AddCommand { get; }

        public StudentControlViewModel()
        {
            Students = UnitOfWork.StudentsRepository.GetAllStudents();
            Usernames = UnitOfWork.UsersRepository.GetUsernames();
            DeleteCommand = new DeleteStudentCommand(this);
            AddCommand = new AddStudentCommand(this);
        }
    }

    public class TeacherControlView : BaseViewModel
    {
        private ObservableCollection<Teacher> _teachers;

        public ObservableCollection<Teacher> Teachers

        {
            get
            {
                return _teachers;
            }
            set
            {
                _teachers = value;
                OnPropertyChanged(nameof(Teachers));
            }
        }

        public TeacherControlView()
        {
            Teachers = UnitOfWork.TeachersRepository.GetAll();
        }
    }
}