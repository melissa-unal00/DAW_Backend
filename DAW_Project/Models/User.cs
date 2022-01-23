using System;
using System.Collections.Generic;
using DAW_Project.Models.Base;

namespace DAW_Project.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<Order> Orders { get; set; }
        public string Gender { get; set; }
        public Role Role { get; set; }
    }
}