using Designer.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer.BLL.Interfaces
{
    public interface IProjectService
    {
        void CreateProject(ProjectDTO dto);

        ProjectDTO GetProjectByUsername(int userId, string projectName);

        List<ProjectDTO> GetAllProjectsByUserId(int id);

    }
}
