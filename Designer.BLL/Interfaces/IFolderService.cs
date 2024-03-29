﻿using Designer.BLL.DTO;
using Designer.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer.BLL.Interfaces
{
    public interface IFolderService
    {
        FolderDTO CreateFolder(FolderDTO dto);

        void DeleteByProjectId(int id);

        void RenameFolder(FolderDTO dto);

        void UpdateLastUpdateDate(FolderDTO dto);

        void UpdateIsSelected(FolderDTO dto);

        void UpdateIsExpanded(FolderDTO dto);

        FolderDTO GetByProjectId(ProjectDTO dto);

        List<FolderDTO> GetByParentFolder(FolderDTO dto);
    }
}
