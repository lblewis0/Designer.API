using Designer.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer.DAL.Interfaces
{
    public interface IUserRepository
    {
        void Create(User user);

        void Delete(int id);

        User GetById(int id);

        User GetByUsername(string username);

        void UpdateActiveProject(User user);

        IEnumerable<User> GetUsers();
    }
}
