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
    public class FolderService : IFolderService
    {
        private readonly IFolderRepository _folderRepository;

        public FolderService(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }

        public FolderDTO CreateFolder(FolderDTO dto)
        {
            Console.WriteLine("FolderService.CreateFolder(FolderDTO).start");

            DateTime parsedCreationDate = DateParser.ParseDate(dto.CreationDate);
            DateTime parsedLastUpdateDate = DateParser.ParseDate(dto.LastUpdateDate);

            Folder newFolder = new Folder();

            newFolder.Id = 0;
            newFolder.Name = dto.Name;
            newFolder.CreationDate = parsedCreationDate;
            newFolder.LastUpdateDate = parsedLastUpdateDate;
            newFolder.ProjectId = dto.ProjectId;
            newFolder.ParentFolderId = dto.ParentFolderId;
            newFolder.IsSelected = dto.IsSelected;
            newFolder.IsExpanded = dto.IsExpanded;

            List<Folder> newFoldersList = new List<Folder>();
            newFoldersList = _folderRepository.GetByParentFolderIdAndNameLike(newFolder.ParentFolderId, newFolder.Name);

            //vérifie si d'autres "newFolder" existe dans le dossier parent
            //si oui, on change le nom en newFolder (2);
            if(newFoldersList.Count > 0)
            {
                newFolder.Name = dto.Name + " (" + (newFoldersList.Count + 1).ToString() + ")";
            }

            _folderRepository.Create(newFolder);

            Folder newFolderWithId = new Folder();
            newFolderWithId = _folderRepository.GetByParentFolderIdAndName(newFolder.ParentFolderId, newFolder.Name);

            FolderDTO returnDTO = new FolderDTO(newFolderWithId);

            Console.WriteLine("FolderService.CreateFolder(FolderDTO).end");
            return returnDTO;
        }

        public void DeleteByProjectId(int id)
        {
            Console.WriteLine("FolderService.DeleteByProjectId(int id).start");

            _folderRepository.DeleteByProjectId(id);

            Console.WriteLine("FolderService.DeleteByProjectId(int id).end");
        }

        public void RenameFolder(FolderDTO dto) 
        {
            Console.WriteLine("FolderService.RenameFolder(FolderDTO).start");

            DateTime parsedCreationDate = DateParser.ParseDate(dto.CreationDate);
            DateTime parsedLastUpdateDate = DateParser.ParseDate(dto.LastUpdateDate);

            Folder newFolder = new Folder();

            newFolder.Id = dto.Id;
            newFolder.Name = dto.Name;
            newFolder.CreationDate = parsedCreationDate;
            newFolder.LastUpdateDate = parsedLastUpdateDate;
            newFolder.ProjectId = dto.ProjectId;
            newFolder.ParentFolderId = dto.ParentFolderId;
            newFolder.IsSelected= dto.IsSelected;
            newFolder.IsExpanded = dto.IsExpanded;

            _folderRepository.Rename(newFolder);

            Console.WriteLine("FolderService.RenameFolder(FolderDTO).end");
        }

        public void UpdateLastUpdateDate(FolderDTO dto)
        {
            Console.WriteLine("FolderService.UpdateLastUpdateDate(FolderDTO).start");

            DateTime parsedCreationDate = DateParser.ParseDate(dto.CreationDate);
            DateTime parsedLastUpdateDate = DateParser.ParseDate(dto.LastUpdateDate);

            Folder newFolder = new Folder();

            newFolder.Id = dto.Id;
            newFolder.Name = dto.Name;
            newFolder.CreationDate = parsedCreationDate;
            newFolder.LastUpdateDate = parsedLastUpdateDate;
            newFolder.ProjectId = dto.ProjectId;
            newFolder.ParentFolderId = dto.ParentFolderId;
            newFolder.IsSelected = dto.IsSelected;
            newFolder.IsExpanded = dto.IsExpanded;

            _folderRepository.UpdateLastUpdateDate(newFolder);

            Console.WriteLine("FolderService.UpdateLastUpdateDate(FolderDTO).end");
        }

        public void UpdateIsSelected(FolderDTO dto)
        {
            Console.WriteLine("FolderService.UpdateIsSelected(FolderDTO).start");

            DateTime parsedCreationDate = DateParser.ParseDate(dto.CreationDate);
            DateTime parsedLastUpdateDate = DateParser.ParseDate(dto.LastUpdateDate);

            Folder newFolder = new Folder();

            newFolder.Id = dto.Id;
            newFolder.Name = dto.Name;
            newFolder.CreationDate = parsedCreationDate;
            newFolder.LastUpdateDate = parsedLastUpdateDate;
            newFolder.ProjectId = dto.ProjectId;
            newFolder.ParentFolderId = dto.ParentFolderId;
            newFolder.IsSelected = dto.IsSelected;
            newFolder.IsExpanded = dto.IsExpanded;

            _folderRepository.UpdateIsSelected(newFolder);

            Console.WriteLine("FolderService.UpdateIsSelected(FolderDTO).end");
        }

        public void UpdateIsExpanded(FolderDTO dto)
        {
            Console.WriteLine("FolderService.UpdateIsExpanded(FolderDTO).start");

            DateTime parsedCreationDate = DateParser.ParseDate(dto.CreationDate);
            DateTime parsedLastUpdateDate = DateParser.ParseDate(dto.LastUpdateDate);

            Folder newFolder = new Folder();

            newFolder.Id = dto.Id;
            newFolder.Name = dto.Name;
            newFolder.CreationDate = parsedCreationDate;
            newFolder.LastUpdateDate = parsedLastUpdateDate;
            newFolder.ProjectId = dto.ProjectId;
            newFolder.ParentFolderId = dto.ParentFolderId;
            newFolder.IsSelected = dto.IsSelected;
            newFolder.IsExpanded = dto.IsExpanded;

            _folderRepository.UpdateIsExpanded(newFolder);

            Console.WriteLine("FolderService.UpdateIsExpanded(FolderDTO).end");
        }

        public FolderDTO GetByProjectId(ProjectDTO dto)
        {
            Console.WriteLine("FolderService.GetByProjectId(ProjectDTO).start");

            Project project = new Project();

            project.Id = dto.Id;
            project.Name = dto.Name;
            project.CreationDate = DateParser.ParseDate(dto.CreationDate);
            project.LastUpdateDate = DateParser.ParseDate(dto.LastUpdateDate);
            project.UserId = dto.UserId;

            Folder folder = _folderRepository.GetByProjectId(project);
            FolderDTO newDto = new FolderDTO(folder);

            Console.WriteLine("FolderService.GetByProjectId(ProjectDTO).end");
            return newDto;
        }

        public List<FolderDTO> GetByParentFolder(FolderDTO dto)
        {
            Console.WriteLine("FolderService.GetByParentFolder(FolderDTO).start");

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

            List<Folder> list = new List<Folder>();
            list = _folderRepository.GetByParentFolder(folder);

            List<FolderDTO> newList = new List<FolderDTO>();
            
            if(list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    var newItem = new FolderDTO(item);
                    newList.Add(newItem);
                }
            }

            Console.WriteLine("FolderService.GetByParentFolder(FolderDTO).end");
            return newList;



        }
    }
}
