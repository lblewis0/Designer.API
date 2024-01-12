using Designer.BLL.Interfaces;
using Designer.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Designer.DAL.Interfaces;
using Designer.DAL.Models;
using Designer.BLL.Mappers;

namespace Designer.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        
        public void UpdateUserActiveProject(UserDTO user)
        {
            Console.WriteLine("UserService.UpdateUserActiveProject(UserDTO, int).start");

            User newUser = UserMapper.Mapper(user);

            _userRepository.UpdateActiveProject(newUser);

            Console.WriteLine("UserService.UpdateUserActiveProject(UserDTO, int).end");

        }
    }
}
