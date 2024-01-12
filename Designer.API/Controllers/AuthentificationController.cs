using Designer.BLL.DTO;
using Designer.BLL.Exceptions;
using Designer.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pastel;
using System.Drawing;
using System.Security.Authentication;

namespace Designer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        private readonly IAuthentificationService _authentificationService;

        private readonly IJwtService _jwtService;

        public AuthentificationController(IAuthentificationService authentificationService, IJwtService jwtService)
        {
            _authentificationService = authentificationService;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO dto)
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("HttpPost request:");
                Console.WriteLine("AuthentificationController.Login(LoginDTO).start".Pastel(Color.Yellow));
                Console.WriteLine(dto);
                Console.WriteLine("");

                UserDTO connectedUser = _authentificationService.Login(dto);

                string token = _jwtService.CreateToken(connectedUser.Id, connectedUser.Email, connectedUser.UserRole);

                TokenDTO tokenDTO = new(connectedUser, token);

                Console.WriteLine("");
                Console.WriteLine("AuthentificationController.Login(LoginDTO).end".Pastel(Color.Yellow));
                Console.WriteLine("HttpPost response: TokenDTO");
                Console.WriteLine(tokenDTO);

                return Ok(tokenDTO);

            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("");
                Console.WriteLine("AuthentificationController.Login(LoginDTO).end".Pastel(Color.Yellow));
                Console.WriteLine("HttpPost response: " + "userNotFound".Pastel(Color.Red));
                return BadRequest(new { message = "userNotFound" });
            }
            catch (WrongPasswordException)
            {
                Console.WriteLine("");
                Console.WriteLine("AuthentificationController.Login(LoginDTO).end".Pastel(Color.Yellow));
                Console.WriteLine("HttpPost response: " + "wrongPassword".Pastel(Color.Red));
                return BadRequest(new { message = "wrongPassword" });
            }
            catch (AuthenticationException)
            {
                return BadRequest("Bad credentials");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
