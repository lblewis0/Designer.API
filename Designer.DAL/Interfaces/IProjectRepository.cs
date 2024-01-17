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

        //void Delete(int id);

        //Project GetById(int id);

        Project GetByUsername(int userId, string projectName);

        IEnumerable<Project> GetAllProjectsByUserId(int id);
    }
}
