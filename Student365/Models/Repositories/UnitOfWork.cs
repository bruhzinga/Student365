using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student365.Models.Repositories
{
    internal static class UnitOfWork
    {
        public static DataBaseContext _bContext;

        public static UsersRepository UsersRepository { get; set; } = new UsersRepository();

        public static User CurrentsUser { get; set; }
    }
}