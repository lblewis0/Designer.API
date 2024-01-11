using Pastel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer.BLL.DTO
{
    public class TokenDTO
    {
        public UserDTO UserDTO { get; set; }

        public string Token { get; set; }

        public TokenDTO(UserDTO userDTO, string token)
        {
            UserDTO = userDTO;
            Token = token;
        }

        public TokenDTO()
        {
        }

        public override string ToString()
        {
            return $"TokenDTO:\n" +
                   $"   Id: {UserDTO.Id.ToString().Pastel(Color.Green)}\n" +
                   $"   Firstname: {UserDTO.Firstname.Pastel(Color.Green)}\n" +
                   $"   Lastname: {UserDTO.Lastname.Pastel(Color.Green)}\n" +
                   $"   Email: {UserDTO.Email.Pastel(Color.Green)}\n" +
                   $"   Username: {UserDTO.Username.Pastel(Color.Green)}\n" +
                   $"   Role: {UserDTO.Role.Pastel(Color.Green)}\n" +
                   $"   Token: {Token.Pastel(Color.Orange)}";
        }
    }
}
