using Pastel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer.BLL.DTO
{
    public class LoginDTO
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public override string ToString()
        {
            return $"LoginDTO:\n" +
                   $"   Username: {Username.Pastel(Color.Green)}\n" +
                   $"   Password: {Password.Pastel(Color.Green)}";
        }
    }
}
