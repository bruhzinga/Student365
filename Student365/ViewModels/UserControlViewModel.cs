using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Student365.Commands.UserControlViewModel;
using Student365.Models;
using Student365.Models.Repositories;

namespace Student365.ViewModels
{
    public class UserControlViewModel : BaseViewModel, IDataErrorInfo
    {
        private ObservableCollection<User> _users;

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        private ObservableCollection<string> _roles;

        public ObservableCollection<string> Roles
        {
            get { return _roles; }
            set
            {
                _roles = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        private User _selected;

        public User Selected
        {
            get { return _selected; }
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
            get { return _newUserName; }
            set
            {
                _newUserName = value;
                OnPropertyChanged(nameof(NewUsername));
            }
        }

        private string _newPassword;

        public string NewPassword
        {
            get { return _newPassword; }
            set
            {
                _newPassword = value;
                OnPropertyChanged(nameof(NewPassword));
            }
        }

        private string _newRole;

        public string NewRole
        {
            get { return _newRole; }
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

        public string vis
        {
            get
            {
                if (UnitOfWork.CurrentsUser.Role == "Admin")
                    return "Visible";
                return "Collapsed";
            }
        }

        string IDataErrorInfo.Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                string error = null;

                switch (columnName)
                {
                    case nameof(NewUsername):
                        if (string.IsNullOrEmpty(NewUsername))
                            error = "Username is required";
                        if (UnitOfWork.UsersRepository.GetUsernames().Contains(NewUsername))
                            error = "Username is already taken";

                        break;

                    case nameof(NewPassword):
                        if (string.IsNullOrEmpty(NewPassword))
                            error = "Password is required";

                        break;

                    case nameof(NewRole):
                        if (string.IsNullOrEmpty(NewRole))
                            error = "Role is required";
                        break;
                }

                return error;
            }
        }
    }

    public class StudentControlViewModel : BaseViewModel, IDataErrorInfo
    {
        private ObservableCollection<Student> _students;

        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged(nameof(Students));
            }
        }

        public static ObservableCollection<string> Usernames
        {
            get { return _usernames; }
            set { _usernames = value; }
        }

        private static ObservableCollection<string> _usernames;

        private string _newName;

        public string NewName
        {
            get { return _newName; }
            set
            {
                _newName = value;
                OnPropertyChanged();
            }
        }

        private string _newUsername;

        public string NewUsername
        {
            get { return _newUsername; }
            set
            {
                _newUsername = value;
                OnPropertyChanged();
            }
        }

        private string _newGroup;

        public string NewGroup
        {
            get { return _newGroup; }
            set
            {
                _newGroup = value;
                OnPropertyChanged();
            }
        }

        private string _newSubgroup;

        public string NewSubgroup
        {
            get { return _newSubgroup; }
            set
            {
                _newSubgroup = value;
                OnPropertyChanged();
            }
        }

        private string _newKurs;

        public string NewKurs

        {
            get { return _newKurs; }

            set
            {
                _newKurs = value;
                OnPropertyChanged();
            }
        }

        private string _newPhone;

        public string NewPhone
        {
            get { return _newPhone; }

            set
            {
                _newPhone = value;
                OnPropertyChanged();
            }
        }

        private Student _selected;

        public Student Selected_Student
        {
            get { return _selected; }
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
            Usernames = UnitOfWork.UsersRepository.GetVacantStudentUsernames();
            DeleteCommand = new DeleteStudentCommand(this);
            AddCommand = new AddStudentCommand(this);
        }

        string IDataErrorInfo.Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                string error = null;

                switch (columnName)
                {
                    case nameof(NewUsername):
                        if (string.IsNullOrEmpty(NewUsername))
                            error = "Username is required";

                        break;

                    case nameof(NewName):
                        if (string.IsNullOrEmpty(NewName))
                            error = "Name is required";
                        break;

                    case nameof(NewGroup)
                        :
                        if (string.IsNullOrEmpty(NewGroup))
                            error = "Group is required";
                        if (!int.TryParse(NewGroup, out int n))
                            error = "Group must be a number";
                        if (n > 10)
                            error = "Group must be less than 10";
                        if (n < 1)
                            error = "Group must be greater than 0";

                        break;

                    case nameof(NewKurs):
                        if (string.IsNullOrEmpty(NewKurs))
                            error = "Kurs is required";
                        if (!int.TryParse(NewKurs, out n))
                            error = "Kurs must be a number";
                        if (n > 5)
                            error = "Kurs must be less than 5";
                        if (n < 1)
                            error = "Kurs must be greater than 0";

                        break;

                    case nameof(NewSubgroup):
                        if (string.IsNullOrEmpty(NewSubgroup))
                            error = "Subgroup is required";
                        if (!int.TryParse(NewSubgroup, out n))
                            error = "Subgroup must be a number";
                        //Subgroup must be 1 or 2;
                        if (n > 2)
                            error = "Subgroup must be less than 3";
                        if (n < 1)
                            error = "Subgroup must be greater than 0";

                        break;

                    case nameof(NewPhone):
                        if (string.IsNullOrEmpty(NewSubgroup))
                            break;

                        if (!double.TryParse(NewPhone, out double _))
                            error = "Phone must be a number";
                        if (NewPhone?.Length < 8 || NewPhone?.Length > 15)
                            error = "Phone must be between 8 and 15 digits";

                        break;
                }

                return error;
            }
        }

        public string vis
        {
            get
            {
                if (UnitOfWork.CurrentsUser.Role == "Admin" || UnitOfWork.CurrentsUser.Role == "Teacher")
                    return "Visible";
                return "Collapsed";
            }
        }
    }

    public class TeacherControlView : BaseViewModel, IDataErrorInfo
    {
        private ObservableCollection<Teacher> _teachers;
        private string _newname;
        private string _newuserName;
        private static ObservableCollection<string> _usernames;

        public ObservableCollection<Teacher> Teachers

        {
            get { return _teachers; }
            set
            {
                _teachers = value;
                OnPropertyChanged(nameof(Teachers));
            }
        }

        public ICommand DeleteCommand { get; }
        public ICommand AddCommand { get; }

        public TeacherControlView()
        {
            Teachers = UnitOfWork.TeachersRepository.GetAll();
            Usernames = UnitOfWork.UsersRepository.GetVacantTeacherUsernames();
            AddCommand = new AddTeacherCommand(this);
            DeleteCommand = new DeleteTeacherCommand(this);
        }

        public string vis
        {
            get
            {
                if (UnitOfWork.CurrentsUser.Role == "Admin")
                    return "Visible";
                return "Collapsed";
            }
        }

        private Teacher _selected;

        public Teacher Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged();
            }
        }

        public static ObservableCollection<string> Usernames
        {
            get => _usernames;
            set
            {
                _usernames = value;
            }
        }

        public string NewName
        {
            get => _newname;
            set
            {
                _newname = value;
                OnPropertyChanged();
            }
        }

        public string NewUsername
        {
            get => _newuserName;
            set
            {
                _newuserName = value;
                OnPropertyChanged();
            }
        }

        string IDataErrorInfo.Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                string error = null;

                switch (columnName)
                {
                    case nameof(NewUsername):
                        if (string.IsNullOrEmpty(NewUsername))
                            error = "Username is required";

                        break;

                    case nameof(NewName):
                        if (string.IsNullOrEmpty(NewName))
                            error = "Name is required";
                        if (NewName?.Length > 50)
                            error = "Name must be less than 50";

                        break;
                }

                return error;
            }
        }
    }
}