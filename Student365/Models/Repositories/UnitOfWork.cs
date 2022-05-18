using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student365.ViewModels;

namespace Student365.Models.Repositories
{
    internal static class UnitOfWork
    {
        public static DataBaseContext _bContext;

        public static UsersRepository UsersRepository { get; set; } = new UsersRepository();

        public static NoteRepository NotesRepository { get; set; } = new NoteRepository();

        public static StudentsRepository StudentsRepository { get; set; } = new StudentsRepository();

        public static LabWorksRepository LabWorksRepository { get; set; } = new LabWorksRepository();

        public static SchedulesRepository ScheduleRepository { get; set; } = new SchedulesRepository();

        public static GroupSubjectsRepository GroupSubjectsRepository { get; set; } = new GroupSubjectsRepository();

        public static AbsenceRepository AbsenceRepository { get; set; } = new AbsenceRepository();
        public static TeachersRepository TeachersRepository { get; set; } = new TeachersRepository();

        public static User CurrentsUser { get; set; }
    }
}