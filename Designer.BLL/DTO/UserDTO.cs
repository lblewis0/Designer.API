using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Designer.DAL.Models;
using Pastel;

namespace Designer.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string UserRole { get; set; }

        public int ActiveProjectId { get; set; }

        public UserDTO(User user)
        {
            Id = user.Id;
            Firstname = user.Firstname;
            Lastname = user.Lastname;
            Email = user.Email;
            Username = user.Username;
            UserRole = user.UserRole;
            ActiveProjectId = user.ActiveProjectId;
        }

        public UserDTO()
        {

        }

        public override string ToString()
        {
            return $"UserDTO:\n" +
                   $"   Id: {Id.ToString().Pastel(Color.Green)}\n" +
                   $"   Firstname: {Firstname.Pastel(Color.Green)}\n" +
                   $"   Lastname: {Lastname.Pastel(Color.Green)}\n" +
                   $"   Email: {Email.Pastel(Color.Green)}\n" +
                   $"   Username: {Username.Pastel(Color.Green)}\n" +
                   $"   Role: {UserRole.Pastel(Color.Green)}\n" +
                   $"   ActiveProjectId: {ActiveProjectId.ToString().Pastel(Color.Green)}";
        }
    }
}
