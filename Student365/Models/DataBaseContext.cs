﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student365.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("Student365Entities")

        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<User> Users { get; set; }
    }
}