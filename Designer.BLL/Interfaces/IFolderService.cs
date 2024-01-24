using Designer.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer.BLL.Interfaces
{
    public interface IFolderService
    {
        void CreateFolder(FolderDTO dto);

        void DeleteByProjectId(int id);

        void RenameFolder(FolderDTO dto);

        FolderDTO GetByProjectId(ProjectDTO dto);

        List<FolderDTO> GetByParentFolder(FolderDTO dto);
    }
}
