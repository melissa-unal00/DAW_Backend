using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAW_Project.Data;
using DAW_Project.DTOs;
using DAW_Project.Models;
using DAW_Project.Repositories.UserRepository;
using DAW_Project.Utilities;
using DAW_Project.Utilities.JWTUtilities;
using Microsoft.Extensions.Options;
using BCryptNet = BCrypt.Net.BCrypt;
using AutoMapper;


namespace DAW_Project.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        public DAW_ProjectContext _context;
        private IJWTUtilities _ijwtUtils;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;


        public UserService(IUserRepository userRepository, DAW_ProjectContext context, IJWTUtilities ijwtUtils, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _userRepository = userRepository;
            _context = context;
            _ijwtUtils = ijwtUtils;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        public RespondUserDTO GetUserByUserId(Guid Id)
        {
            User user = _userRepository.FindById(Id);
            RespondUserDTO userRespondDto = _mapper.Map<RespondUserDTO>(user);
            return userRespondDto;
        }

        public void CreateUser(RegisterUserDTO user)
        {

            // verific ca username ul si emailul sa fie unice(sa nu se regaseasca in baza de date)
            if (_userRepository.GetByEmail(user.Email) != null || _userRepository.GetByUsername(user.Username) != null)
                throw new Exception("Email or username already exists");

            var userToCreate = _mapper.Map<User>(user);
            userToCreate.Role = Role.User;
            userToCreate.Password = BCryptNet.HashPassword(user.Password);
            userToCreate.DateCreated = DateTime.Now;
            userToCreate.DateModified = DateTime.Now;

            _userRepository.Create(userToCreate);
            _userRepository.Save();
        }

        public void CreateAdmin(RegisterUserDTO user)
        {

            // verific ca username ul si emailul sa fie unice(sa nu se regaseasca in baza de date)
            if (_userRepository.GetByEmail(user.Email) != null || _userRepository.GetByUsername(user.Username) != null)
                throw new Exception("Email or username already exists");

            var userToCreate = _mapper.Map<User>(user);

            userToCreate.Role = Role.Admin;
            userToCreate.Password = BCryptNet.HashPassword(user.Password);
            userToCreate.DateCreated = DateTime.Now;
            userToCreate.DateModified = DateTime.Now;

            _userRepository.Create(userToCreate);
            _userRepository.Save();
        }


        public List<RespondUserDTO> GetAllUsers()
        {
            List<User> usersList = _userRepository.GetAllUsers();
            List<RespondUserDTO> userRespondDto = _mapper.Map<List<RespondUserDTO>>(usersList);
            return userRespondDto;
        }

        public List<RespondUserDTO> GetAllUsersByName(string name)
        {
            List<User> usersList = _userRepository.GetAllUsersByName(name);
            List<RespondUserDTO> userRespondDto = _mapper.Map<List<RespondUserDTO>>(usersList);
            return userRespondDto;
        }

        public void DeleteUserById(Guid id)
        {
            User user = _userRepository.FindById(id);
            _userRepository.Delete(user);
            _userRepository.Save();
        }

        public void UpdateUser(RegisterUserDTO newUser, Guid id)
        {
            User user = _userRepository.FindById(id);

            if (newUser.FirstName != null)
                user.FirstName = newUser.FirstName;

            if (newUser.LastName != null)
                user.LastName = newUser.LastName;

            if (newUser.Email != null)
                user.Email = newUser.Email;

            if (newUser.Username != null)
                user.Username = newUser.Username;

            if (newUser.Password != null)
                user.Password = newUser.Password;

            user.DateModified = DateTime.Now;

            _userRepository.Save();
        }

        public TokenUserDTO Authentificate(LoginUserDTO model)
        {

            var user = _context.Users.FirstOrDefault(x => x.Username.Equals(model.Username));

            if (user == null || !BCryptNet.Verify(model.Password, user.Password))
            {
                return null;
            }

            //generam jwt token
            var jwtToken = _ijwtUtils.GenerateJWTToken(user);
            return new TokenUserDTO(user, jwtToken);
        }

        public TokenUserDTO Authenticate(LoginUserDTO model) //asta e o metoda care verifica parolele (hash-ul cu parola noastra)
        {

            var user = _context.Users.FirstOrDefault(x => x.Username.Equals(model.Username));

            if (user == null || !BCryptNet.Verify(model.Password, user.Password))
            {
                return null;
            }

            //generam jwt token
            var jwtToken = _ijwtUtils.GenerateJWTToken(user);
            return new TokenUserDTO(user, jwtToken);
        }
    }
}