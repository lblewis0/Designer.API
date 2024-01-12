using Designer.BLL.DTO;
using Designer.BLL.Interfaces;
using Designer.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pastel;
using System.Drawing;

namespace Designer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

                Console.WriteLine("");
                Console.WriteLine("UserController.UpdateActiveProject(TokenDTO).end".Pastel(Color.Yellow));
                Console.WriteLine("HttpPost response: Ok()");

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
