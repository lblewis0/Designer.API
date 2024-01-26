using Designer.BLL.DTO;
using Designer.BLL.Exceptions;
using Designer.BLL.Interfaces;
using Designer.BLL.Utils;
using Designer.DAL.Interfaces;
using Designer.DAL.Models;
using Designer.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer.BLL.Services
{
    public class ComponentService : IComponentService
    {
        private readonly IComponentRepository _componentRepository;

        public ComponentService(IComponentRepository componentRepository)
        {
            _componentRepository = componentRepository;
        }

        public void CreateComponent(ComponentDTO dto)
        {
            Console.WriteLine("ComponentService.CreateComponent(ComponentDTO).start");

            DateTime parsedCreationDate = DateParser.ParseDate(dto.CreationDate);
            DateTime parsedLastUpdateDate = DateParser.ParseDate(dto.LastUpdateDate);

            Component newComponent = new Component();

            newComponent.Id = 0;
            newComponent.Name = dto.Name;
            newComponent.CreationDate = parsedCreationDate;
            newComponent.LastUpdateDate = parsedLastUpdateDate;
            newComponent.ProjectId = dto.ProjectId;
            newComponent.ParentFolderId = dto.ParentFolderId;
            newComponent.IsSelected = dto.IsSelected;
            newComponent.IsExpanded = dto.IsExpanded;


            _componentRepository.Create(newComponent);

            Console.WriteLine("ComponentService.CreateComponent(ComponentDTO).end");
        }

        public List<ComponentDTO> GetComponentsByParentFolder(FolderDTO dto)
        {
            Console.WriteLine("ComponentService.GetComponentsByParentFolder(FolderDTO).start");

            Folder folder = new Folder();

            folder.Id = dto.Id;
            folder.Name = dto.Name;
            folder.CreationDate = DateParser.ParseDate(dto.CreationDate);
            folder.LastUpdateDate = DateParser.ParseDate(dto.LastUpdateDate);
            folder.ProjectId = dto.ProjectId;
            folder.ParentFolderId = dto.ParentFolderId;
            folder.IsEditable = dto.IsEditable;
            folder.IsSelected = dto.IsSelected;
            folder.IsExpanded = dto.IsExpanded;

            List<Component> list = new List<Component>();
            list = _componentRepository.GetByParentFolder(folder);

            List<ComponentDTO> newList = new List<ComponentDTO>();

            if(list != null && list.Count > 0)
            {
                foreach(var item in list)
                {
                    var newItem = new ComponentDTO(item);
                    newList.Add(newItem);
                }
            }

            Console.WriteLine("ComponentService.GetComponentsByParentFolder(FolderDTO).end");
            return newList;

            
        }
    }
}
