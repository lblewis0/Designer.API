using Designer.BLL.DTO;
using Designer.BLL.Exceptions;
using Designer.BLL.Interfaces;
using Designer.BLL.Services;
using Designer.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pastel;
using System.Drawing;

namespace Designer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        private readonly IComponentService _componentService;

        public ComponentController(IComponentService componentService)
        {
            _componentService = componentService;
        }

        [HttpPost("createComponent")]
        public IActionResult CreateComponent([FromBody] ComponentDTO dto)
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("HttpPost request:");
                Console.WriteLine("ComponentController.CreateComponent(ComponentDTO).start".Pastel(Color.Yellow));
                Console.WriteLine(dto);
                Console.WriteLine("");

                _componentService.CreateComponent(dto);

                Console.WriteLine("");
                Console.WriteLine("ComponentController.CreateComponent(ComponentDTO).end".Pastel(Color.Yellow));
                Console.WriteLine("HttpPost response: Ok()");

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("getComponentsByParentFolder")]
        public IActionResult GetComponentsByParentFolder([FromBody] FolderDTO dto)
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("HttpPost request:");
                Console.WriteLine("ComponentController.GetComponentsByParentFolder(ComponentDTO).start".Pastel(Color.Yellow)); 
                Console.WriteLine(dto);
                Console.WriteLine("");

                List<ComponentDTO> components = _componentService.GetComponentsByParentFolder(dto);

                Console.WriteLine("");
                Console.WriteLine("ComponentController.GetComponentsByParentFolder(ComponentDTO).end".Pastel(Color.Yellow));

                if (components.Count > 0)
                {
                    Console.WriteLine("HttpPost response: List<ComponentDTO>");
                    Console.WriteLine(components);
                }
                else
                {
                    Console.WriteLine("HttpPost response: " + "ComponentsNotFound".Pastel(Color.Red));
                }

                return Ok(components);
                //return Ok();
            }
            catch (NoComponentsFoundException)
            {
                return NotFound(new { message = "ComponentsNotFound" });
            }
        }
    }
}
