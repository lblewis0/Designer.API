using Designer.BLL.DTO;
using Designer.BLL.Interfaces;
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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IFolderService _folderService;
        private readonly IUserService _userService;

        public ProjectController(IProjectService projectService, IFolderService folderService, IUserService userService)
        {
            _projectService = projectService;
            _folderService = folderService;
            _userService = userService;
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

                ProjectDTO dtoAfter = _projectService.GetProjectByUsername(dto.UserId, dto.Name);

                UserDTO user = _userService.GetById(dto.UserId);
                user.ActiveProjectId = dtoAfter.Id;

                _userService.UpdateUserActiveProject(user);

                FolderDTO mainFolder = new FolderDTO();

                mainFolder.Name = dto.Name;
                mainFolder.CreationDate = dto.CreationDate;
                mainFolder.LastUpdateDate = dto.LastUpdateDate;
                mainFolder.ProjectId = dtoAfter.Id;
                mainFolder.IsEditable = false;
                mainFolder.IsSelected = false;
                mainFolder.IsExpanded = false;
                mainFolder.ParentFolderId = 0;

                _folderService.CreateFolder(mainFolder);

                Console.WriteLine("");
                Console.WriteLine("ProjectController.CreateProject(ProjectDTO).end".Pastel(Color.Yellow));
                Console.WriteLine("HttpPost response: Ok(UserDTO)");
                Console.WriteLine(user);

                return Ok(user);
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
                foreach (ProjectDTO dto in list)
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

        [HttpPost("renameProject")]
        public IActionResult RenameProject([FromBody] ProjectDTO dto)
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("HttpPost request:");
                Console.WriteLine("ProjectController.RenameProject(ProjectDTO).start".Pastel(Color.Yellow));
                Console.WriteLine(dto);
                Console.WriteLine("");

                _projectService.RenameProject(dto);

                Console.WriteLine("");
                Console.WriteLine("ProjectController.RenameProject(ProjectDTO).end".Pastel(Color.Yellow));
                Console.WriteLine("HttpPost response: Ok()");

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("deleteProject")]
        public IActionResult DeleteProject([FromBody] ProjectDTO dto)
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("HttpPost request:");
                Console.WriteLine("ProjectController.DeleteProject(ProjectDTO).start".Pastel(Color.Yellow));
                Console.WriteLine(dto);
                Console.WriteLine("");

                _folderService.DeleteByProjectId(dto.Id);
                _projectService.DeleteProject(dto);

                Console.WriteLine("");
                Console.WriteLine("ProjectController.DeleteProject(ProjectDTO).end".Pastel(Color.Yellow));
                Console.WriteLine("HttpPost response: Ok()");

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("updateLastUpdateDate")]
        public IActionResult UpdateLastUpdateDate([FromBody] ProjectDTO dto)
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("HttpPost request:");
                Console.WriteLine("ProjectController.UpdateLastUpdateDate(ProjectDTO).start".Pastel(Color.Yellow));
                Console.WriteLine(dto);
                Console.WriteLine("");

                _projectService.UpdateLastUpdateDate(dto);

                Console.WriteLine("");
                Console.WriteLine("ProjectController.UpdateLastUpdateDate(ProjectDTO).end".Pastel(Color.Yellow));
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
