using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer.DAL.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public int UserId { get; set; }

    }
}
