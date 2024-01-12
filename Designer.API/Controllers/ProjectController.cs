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
                Console.WriteLine("ProjectController.CreateProject(ProjectDTO).end".Pastel(Color.Yellow));
                Console.WriteLine("HttpPost response: Ok()");

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("getProjects")]
        public IActionResult GetProjects([FromBody] TokenDTO token)
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("HttpPost request:");
                Console.WriteLine("ProjectController.GetProjects(TokenDTO).start".Pastel(Color.Yellow));
                Console.WriteLine("");

                List<ProjectDTO> list = _projectService.GetAllProjectsByUserId(token.UserDTO.Id);

                Console.WriteLine("");
                Console.WriteLine("ProjectController.GetProjects(TokenDTO).end".Pastel(Color.Yellow));
                Console.WriteLine("HttpPost response: List<Projects>");
                foreach(ProjectDTO dto in list)
                {
                    Console.WriteLine(dto);
                }

                return Ok(list);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

}
