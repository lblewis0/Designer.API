using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer.BLL.Interfaces
{
    public interface IJwtService
    {
        string CreateToken(int identifier, string email, string role);
    }
}
