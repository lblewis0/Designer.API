using Designer.BLL.DTO;
using Designer.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pastel;
using System.Drawing;

namespace Designer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost("createProject")]
        public IActionResult CreateProject([FromBody] ProjectDTO dto)
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("HttpPost request:");
                Console.WriteLine("ProjectController.CreateProject(ProjectDTO).start".Pastel(Color.Yellow));
                Console.WriteLine(dto);
                Console.WriteLine("");

                _projectService.CreateProject(dto);

                Console.WriteLine("");
                Console.WriteLine("AuthentificationController.Login(LoginDTO).end".Pastel(Color.Yellow));
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
