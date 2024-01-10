using Designer.BLL.DTO;
using Designer.BLL.Exceptions;
using Designer.BLL.Interfaces;
using Designer.DAL.Models;
using Designer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer.BLL.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly IUserRepository _userRepository;

        public AuthentificationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDTO Login(LoginDTO dto)
        {
            Console.WriteLine("AuthentificationService.Login(LoginDTO).start");
            User? user = _userRepository.GetByUsername(dto.Username);

            if (user == null)
            {
                throw new KeyNotFoundException(dto.Username);
            }

            if (dto.Password != user.Password)
            {
                throw new WrongPasswordException();
            }

            UserDTO userDTO = new UserDTO(user);

            Console.WriteLine("AuthentificationService.Login(LoginDTO).end");
            return userDTO;
        }
    }
}
