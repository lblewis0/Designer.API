using Designer.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer.DAL.Interfaces
{
    public interface IComponentRepository
    {
        void Create(Component component);

        void UpdateIsSelected(Component component);

        void UpdateIsExpanded(Component component);

        List<Component> GetByParentFolder(Folder folder);
    }
}
