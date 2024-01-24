using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer.BLL.DTO
{
    public class ComponentTreeElementDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CreationDate { get; set; }

        public string LastUpdateDate { get; set; }

        public int ProjectId { get; set; }

        public int ParentFolderId { get; set; }

        public bool IsSelected { get; set; }

        public bool IsExpanded { get; set; }

        public int Indent { get; set; }

        public string Type { get; set; }

        public List<ComponentTreeElementDTO> Children { get; set; }

        public ComponentTreeElementDTO()
        { 
            Children = new List<ComponentTreeElementDTO>();

        }

    }
}
