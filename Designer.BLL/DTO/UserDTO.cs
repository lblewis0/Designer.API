using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Designer.DAL.Models;

namespace Designer.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Role { get; set; }

        public UserDTO(User user)
        {
            Id = user.Id;
            Firstname = user.Firstname;
            Lastname = user.Lastname;
            Email = user.Email;
            Username = user.Username;
            Role = user.Role;
        }

        public UserDTO()
        {

        }
    }
}
