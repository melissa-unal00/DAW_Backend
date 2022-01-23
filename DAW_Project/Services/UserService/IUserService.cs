using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAW_Project.DTOs;
using DAW_Project.Models;

namespace DAW_Project.Services.UserService
{
    public interface IUserService
    {
        RespondUserDTO GetUserByUserId(Guid Id);
        public List<RespondUserDTO> GetAllUsers();
        public List<RespondUserDTO> GetAllUsersByName(string name);

        void CreateUser(RegisterUserDTO entity);
        void CreateAdmin(RegisterUserDTO entity);

        void DeleteUserById(Guid id);
        void UpdateUser(RegisterUserDTO user, Guid id);
        TokenUserDTO Authenticate(LoginUserDTO model);
    }
}