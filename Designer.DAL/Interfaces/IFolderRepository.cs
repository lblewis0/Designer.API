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

        Folder GetByProjectId(Project project);

        List<Folder> GetByParentFolder(Folder folder);
    }
}
