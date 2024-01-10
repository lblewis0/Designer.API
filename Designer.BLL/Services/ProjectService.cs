using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Designer.BLL.DTO;
using Designer.BLL.Interfaces;
using Designer.DAL.Interfaces;
using Designer.DAL.Models;
using Microsoft.AspNetCore.Http;
using Pastel;
using System.Drawing;

namespace Designer.BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public void CreateProject(ProjectDTO dto)
        {
            Console.WriteLine("ProjectService.CreateProject(ProjectDTO).start");

            DateTime parsedCreationDate = ParseDate(dto.CreationDate);
            DateTime parsedLastUpdateDate = ParseDate(dto.LastUpdateDate);

            Project newProject = new Project();

            newProject.Id = 0;
            newProject.Name = dto.Name;
            newProject.CreationDate = parsedCreationDate;
            newProject.LastUpdateDate = parsedLastUpdateDate;
            newProject.UserId = dto.UserId;

            _projectRepository.Create(newProject);

            Console.WriteLine("ProjectService.CreateProject(ProjectDTO).end");

        }

        public DateTime ParseDate(string date)
        {
            string format = "yyyy-MM-dd'T'HH:mm:ss.fff'Z'";
            IFormatProvider provider = CultureInfo.InvariantCulture;
            var styles = DateTimeStyles.None;

            DateTime parsedDate = new DateTime();

            try
            {
                parsedDate = DateTime.ParseExact(date, format, provider, styles);
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            return parsedDate;
        }
    }
}
