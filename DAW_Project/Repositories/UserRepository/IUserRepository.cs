using System;
using System.Collections.Generic;
using System.Linq;
using DAW_Project.DTOs;
using DAW_Project.Models;
using DAW_Project.Repositories.GenericRepository;

namespace DAW_Project.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        List<User> GetAllUsers();
        List<User> GetAllUsersByName(string name);
        User GetByUsername(string name);
        User GetByEmail(string name);

    }
}