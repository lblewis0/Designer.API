using Designer.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer.DAL.Interfaces
{
    public interface IProjectRepository
    {
        void Create(Project project);

        Project GetByUsername(int userId, string projectName);

        IEnumerable<Project> GetAllProjectsByUserId(int id);

        void Rename(Project project);

        void DeleteById(int id);

        void UpdateLastUpdateDate(Project project);
    }
}
