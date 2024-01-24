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

        public bool IsEditable { get; set; }

        public bool IsSelected { get; set; }

        public bool IsExpanded { get; set; }

        public FolderDTO(Folder folder)
        {
            Id = folder.Id;
            Name = folder.Name;
            CreationDate = folder.CreationDate.ToString();
            LastUpdateDate = folder.LastUpdateDate.ToString();
            ProjectId = folder.ProjectId;
            ParentFolderId = folder.ParentFolderId;
            IsEditable = folder.IsEditable;
            IsSelected = folder.IsSelected;
            IsExpanded = folder.IsExpanded;
        }

        public FolderDTO()
        {
            
        }

        public override string ToString()
        {
            return $"FolderDTO:\n" +
                   $"   Id: {Id.ToString().Pastel(Color.Green)}\n" +
                   $"   Name: {Name.Pastel(Color.Green)}\n" +
                   $"   CreationDate: {CreationDate.ToString().Pastel(Color.Green)}\n" +
                   $"   LastUpdateDate: {LastUpdateDate.ToString().Pastel(Color.Green)}\n" +
                   $"   ProjectId: {ProjectId.ToString().Pastel(Color.Green)}\n" +
                   $"   ParentFolderId: {ParentFolderId.ToString().Pastel(Color.Green)}\n" +
                   $"   IsEditable: {IsEditable.ToString().Pastel(Color.Green)}\n" +
                   $"   IsSelected: {IsSelected.ToString().Pastel(Color.Green)}\n" +
                   $"   IsExpanded: {IsExpanded.ToString().Pastel(Color.Green)}";

        }
    }
}
