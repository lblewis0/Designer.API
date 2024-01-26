using Designer.BLL.DTO;
using Designer.BLL.Exceptions;
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
    public class FolderController : ControllerBase
    {
        private readonly IFolderService _folderService;

        public FolderController(IFolderService folderService)
        {
            _folderService = folderService;
        }

        [HttpPost("createFolder")]
        public IActionResult CreateFolder([FromBody] FolderDTO dto)
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("HttpPost request:");
                Console.WriteLine("FolderController.CreateFolder(FolderDTO).start".Pastel(Color.Yellow));
                Console.WriteLine(dto);
                Console.WriteLine("");

                _folderService.CreateFolder(dto);

                Console.WriteLine("");
                Console.WriteLine("FolderController.CreateFolder(FolderDTO).end".Pastel(Color.Yellow));
                Console.WriteLine("HttpPost response: Ok()");

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("renameFolder")]
        public IActionResult RenameFolder([FromBody] FolderDTO dto)
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("HttpPost request:");
                Console.WriteLine("FolderController.RenameFolder(FolderDTO).start".Pastel(Color.Yellow));
                Console.WriteLine(dto);
                Console.WriteLine("");

                _folderService.RenameFolder(dto);

                Console.WriteLine("");
                Console.WriteLine("FolderController.RenameFolder(FolderDTO).end".Pastel(Color.Yellow));
                Console.WriteLine("HttpPost response: Ok()");

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("getFolderByProjectId")]
        public IActionResult GetFolderByProjectId([FromBody] ProjectDTO dto)
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("HttpPost request:");
                Console.WriteLine("FolderController.getMainFolder(ProjectDTO).start".Pastel(Color.Yellow));
                Console.WriteLine("");

                FolderDTO folder = _folderService.GetByProjectId(dto);

                Console.WriteLine("");
                Console.WriteLine("FolderController.getMainFolder(ProjectDTO).end".Pastel(Color.Yellow));
                Console.WriteLine("HttpPost response: FolderDTO");
                Console.WriteLine(folder);

                return Ok(folder);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost("getFoldersByParentFolder")]
        public IActionResult GetFoldersByParentFolder([FromBody] FolderDTO dto)
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("HttpPost request:");
                Console.WriteLine("FolderController.getFoldersByParentFolder(FolderDTO).start".Pastel(Color.Yellow));
                Console.WriteLine("");

                List<FolderDTO> folders = _folderService.GetByParentFolder(dto);

                Console.WriteLine("");
                Console.WriteLine("FolderController.getFoldersByParentFolder(FolderDTO).end".Pastel(Color.Yellow));
                

                if (folders.Count > 0)
                {
                    Console.WriteLine("HttpPost response: List<FolderDTO>");
                    Console.WriteLine(folders);
                }
                else
                {
                    Console.WriteLine("HttpPost response: " + "FoldersNotFound".Pastel(Color.Red));
                }
                

                return Ok(folders);
            }
            catch (NoFoldersFoundException)
            {
                return NotFound(new { message = "FoldersNotFound" });
            }
        }
    }
}
