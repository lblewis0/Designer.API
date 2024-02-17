using Designer.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer.BLL.Interfaces
{
    public interface IComponentService
    {
        void CreateComponent(ComponentDTO dto);

        void UpdateIsSelected(ComponentDTO dto);

        void UpdateIsExpanded(ComponentDTO dto);

        List<ComponentDTO> GetComponentsByParentFolder(FolderDTO dto);
    }
}
