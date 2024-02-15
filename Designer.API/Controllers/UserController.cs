using Designer.BLL.DTO;
using Designer.BLL.Interfaces;
using Designer.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pastel;
using System.Drawing;

namespace Designer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("updateActiveProject")]
        public IActionResult UpdateActiveProject([FromBody] TokenDTO dto)
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("HttpPost request:");
                Console.WriteLine("UserController.UpdateActiveProject(TokenDTO).start".Pastel(Color.Yellow));
                Console.WriteLine(dto);
                Console.WriteLine("");

                _userService.UpdateUserActiveProject(dto.UserDTO);
                UserDTO newDTO = _userService.GetById(dto.UserDTO.Id);

                Console.WriteLine("");
                Console.WriteLine("UserController.UpdateActiveProject(TokenDTO).end".Pastel(Color.Yellow));
                Console.WriteLine("HttpPost response: Ok()");

                return Ok(newDTO);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
