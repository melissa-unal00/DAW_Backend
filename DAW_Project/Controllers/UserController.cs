using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAW_Project.Data;
using DAW_Project.DTOs;
using DAW_Project.Models;
using DAW_Project.Services.UserService;
using DAW_Project.Utilities.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using DAW_Project.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace DAW_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly DAW_ProjectContext _context;

        public UserController(IUserService userService, DAW_ProjectContext context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(LoginUserDTO user)
        {
            var response = _userService.Authenticate(user);

            if (response == null)
            {
                return BadRequest(new { Message = "Incorrect username or password!" });
            }

            return Ok(response);
        }

        //GET
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("byId")]
        public IActionResult GetByIdWithDto(Guid Id)
        {
            return Ok(_userService.GetUserByUserId(Id));
        }

        [AuthorizationAttribute(Role.Admin)]
        [HttpGet("allUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }


        [AuthorizationAttribute(Role.Admin)]
        [HttpGet("byname")]
        public IActionResult GetAllUsersByName(string name)
        {
            return Ok(_userService.GetAllUsersByName(name));
        }

        //POST
        [HttpPost("createUser")]
        public IActionResult CreateUser(RegisterUserDTO user)
        {
            _userService.CreateUser(user);
            return Ok();
        }
        [HttpPost("createAdmin")]
        public IActionResult CreateAdmin(RegisterUserDTO user)
        {
            _userService.CreateAdmin(user);
            return Ok();
        }

        //PUT
        [HttpPut("updateUser")]
        public IActionResult Update(RegisterUserDTO user, Guid id)
        {
            _userService.UpdateUser(user, id);
            return Ok();
        }


        //DELETE
        [AuthorizationAttribute(Role.Admin)]
        [HttpDelete]
        public IActionResult DeleteById(Guid Id)
        {
            _userService.DeleteUserById(Id);
            return Ok();
        }
    }
}