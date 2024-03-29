﻿using Designer.BLL.DTO;
using Designer.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer.BLL.Interfaces
{
    public interface IUserService
    {
        void UpdateUserActiveProject(UserDTO user);

        UserDTO GetById(int id);
    }
}
