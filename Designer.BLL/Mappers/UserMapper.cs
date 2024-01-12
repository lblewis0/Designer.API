using Designer.BLL.DTO;
using Designer.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer.BLL.Mappers
{
    public static class UserMapper
    {
        public static User Mapper (UserDTO dto)
        {
            return new User
            {
                Id = dto.Id,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
                Email = dto.Email,
                Username = dto.Username,
                Password = null,
                UserRole = dto.UserRole,
                ActiveProjectId = dto.ActiveProjectId
            };
        }
    }
}
