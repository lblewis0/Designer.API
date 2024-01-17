using Designer.DAL.Models;
using Pastel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer.BLL.DTO
{
    public class FolderDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CreationDate { get; set; }

        public string LastUpdateDate { get; set; }

        public int ProjectId { get; set; }

        public int ParentFolderId { get; set; }

        public List<FolderDTO> ChildsFolders { get; set; }

        public FolderDTO(Folder folder)
        {
            Id = folder.Id;
            Name = folder.Name;
            CreationDate = folder.CreationDate.ToString();
            LastUpdateDate = folder.LastUpdateDate.ToString();
            ProjectId = folder.ProjectId;
            ParentFolderId = folder.ParentFolderId;
            ChildsFolders = new List<FolderDTO> { };
        }

        public FolderDTO()
        {
            ChildsFolders = new List<FolderDTO> { };
        }

        public override string ToString()
        {
            return $"FolderDTO:\n" +
                   $"   Id: {Id.ToString().Pastel(Color.Green)}\n" +
                   $"   Name: {Name.Pastel(Color.Green)}\n" +
                   $"   CreationDate: {CreationDate.ToString().Pastel(Color.Green)}\n" +
                   $"   LastUpdateDate: {LastUpdateDate.ToString().Pastel(Color.Green)}\n" +
                   $"   ProjectId: {ProjectId.ToString().Pastel(Color.Green)}" +
                   $"   ParentFolderId: {ParentFolderId.ToString().Pastel(Color.Green)}";
        }
    }
}
