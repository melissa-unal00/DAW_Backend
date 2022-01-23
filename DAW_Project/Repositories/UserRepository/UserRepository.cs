using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAW_Project.Data;
using DAW_Project.DTOs;
using DAW_Project.Models;
using DAW_Project.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DAW_Project.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DAW_ProjectContext _context;

        public UserRepository(DAW_ProjectContext context) : base(context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return new List<User>(_context.Users.AsNoTracking().ToList());
        }

        public List<User> GetAllUsersByName(string name)
        {
            return new List<User>(_context.Users.Where(u => u.FirstName.Equals(name) || u.LastName.Equals(name)));
        }

        public User GetByUsername(string name)
        {
            return _context.Users.FirstOrDefault(u => u.Username.Equals(name));
        }

        public User GetByEmail(string name)
        {
            return _context.Users.FirstOrDefault(u => u.Email.Equals(name));
        }

    }
}