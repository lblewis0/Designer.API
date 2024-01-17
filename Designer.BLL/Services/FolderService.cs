using Designer.BLL.DTO;
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

        public void CreateFolder(FolderDTO dto)
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

            _folderRepository.Create(newFolder);

            Console.WriteLine("FolderService.CreateFolder(FolderDTO).end");
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

            _folderRepository.Rename(newFolder);

            Console.WriteLine("FolderService.RenameFolder(FolderDTO).end");
        }
    }
}
