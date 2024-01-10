using Pastel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer.BLL.DTO
{
    public class ProjectDTO
    {
        public string Name { get; set; }

        public string CreationDate { get; set; }

        public string LastUpdateDate { get; set; }

        public int UserId { get; set; }

        public override string ToString()
        {
            return $"LoginProjectDTO:\n" +
                   $"   Name: {Name.Pastel(Color.Green)}\n" +
                   $"   CreationDate: {CreationDate.ToString().Pastel(Color.Green)}\n" +
                   $"   LastUpdateDate: {LastUpdateDate.ToString().Pastel(Color.Green)}\n" +
                   $"   UserId: {UserId.ToString().Pastel(Color.Green)}";
        }
    }
}
