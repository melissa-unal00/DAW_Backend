using System;

namespace DAW_Project.DTOs
{
    public class RegisterUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
    }
}