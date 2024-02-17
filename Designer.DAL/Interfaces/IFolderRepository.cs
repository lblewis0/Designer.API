using Designer.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer.DAL.Interfaces
{
    public interface IFolderRepository
    {
        void Create(Folder folder);

        void DeleteByProjectId(int projectId);

        void Rename(Folder folder);

        void UpdateLastUpdateDate(Folder folder);

        void UpdateIsSelected(Folder folder);

        void UpdateIsExpanded(Folder folder);

        Folder GetByProjectId(Project project);

        List<Folder> GetByParentFolder(Folder folder);

        List<Folder> GetByParentFolderIdAndNameLike(int parentFolderId, string name);

        Folder GetByParentFolderIdAndName(int parentFolderId, string name);
    }
}
