using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Designer.BLL.DTO;
using Designer.BLL.Interfaces;
using Designer.DAL.Interfaces;
using Designer.BLL.Utils;
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

            DateTime parsedCreationDate = DateParser.ParseDate(dto.CreationDate);
            DateTime parsedLastUpdateDate = DateParser.ParseDate(dto.LastUpdateDate);

            Project newProject = new Project();

            newProject.Id = 0;
            newProject.Name = dto.Name;
            newProject.CreationDate = parsedCreationDate;
            newProject.LastUpdateDate = parsedLastUpdateDate;
            newProject.UserId = dto.UserId;

            _projectRepository.Create(newProject);

            Console.WriteLine("ProjectService.CreateProject(ProjectDTO).end");

        }

        public ProjectDTO GetProjectByUsername(int userId, string projectName)
        {
            Console.WriteLine("ProjectService.GetProjectByUsername(int userId, string projectName).start");

            ProjectDTO dto = new ProjectDTO(_projectRepository.GetByUsername(userId, projectName));

            Console.WriteLine("ProjectService.GetProjectByUsername(int userId, string projectName).end");

            return dto;

        }

        public List<ProjectDTO> GetAllProjectsByUserId(int id) 
        {
            Console.WriteLine("ProjectService.GetAllProjectsByUserId(int).start");

            IEnumerable<Project> projectsDB = _projectRepository.GetAllProjectsByUserId(id);
            List<ProjectDTO> projectsDTO = new List<ProjectDTO>();

            foreach(var project in projectsDB)
            {
                ProjectDTO parsedProject = new ProjectDTO(project);
                projectsDTO.Add(parsedProject);
            }

            Console.WriteLine("ProjectService.GetAllProjectsByUserId(int).end");
            return projectsDTO;

        }

        public void RenameProject(ProjectDTO dto)
        {
            Console.WriteLine("ProjectService.RenameProject(ProjectDTO).start");

            DateTime parsedCreationDate = DateParser.ParseDate(dto.CreationDate);
            DateTime parsedLastUpdateDate = DateParser.ParseDate(dto.LastUpdateDate);

            Project newProject = new Project();

            newProject.Id = dto.Id;
            newProject.Name = dto.Name;
            newProject.CreationDate = parsedCreationDate;
            newProject.LastUpdateDate = parsedLastUpdateDate;
            newProject.UserId = dto.UserId;

            _projectRepository.Rename(newProject);

            Console.WriteLine("ProjectService.RenameProject(ProjectDTO).end");
        }

        public void DeleteProject(ProjectDTO dto)
        {
            Console.WriteLine("ProjectService.DeleteProject(ProjectDTO).start");

            _projectRepository.DeleteById(dto.Id);

            Console.WriteLine("ProjectService.DeleteProject(ProjectDTO).end");

        }
    }
}
