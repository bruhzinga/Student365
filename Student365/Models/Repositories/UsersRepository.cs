﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Student365.Models.Repositories
{
    internal class UsersRepository : IGenericRepository<User>
    {
        private DbContext _context = new DataBaseContext();
        private DbSet<User> _dbSet;

        public UsersRepository()
        {
            _dbSet = _context.Set<User>();
        }

        public void Create(User item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public User FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<User> Get()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<User> Get(Func<User, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public void Remove(User item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public void Update(User item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void AddAdmin()
        {
            var Hash = SHA256.Create();
            byte[] data = Hash.ComputeHash(Encoding.UTF8.GetBytes("Admin"));
            Create(new User()
            {
                UserName = "Admin",
                Role = "Admin",
                PasswordHash = data
            });
        }

        public object GetUser(string viewModelUsername, string viewModelPassword)
        {
            var Hash = SHA256.Create();
            byte[] data = Hash.ComputeHash(Encoding.UTF8.GetBytes(viewModelPassword));

            return _dbSet.FirstOrDefault(x => x.UserName == viewModelUsername && x.PasswordHash == data);
        }
    }
}