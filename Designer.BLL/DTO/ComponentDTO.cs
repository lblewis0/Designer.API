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
    public class ComponentDTO
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

        public ComponentDTO(Component component)
        {
            Id = component.Id;
            Name = component.Name;
            CreationDate = component.CreationDate.ToString();
            LastUpdateDate = component.LastUpdateDate.ToString();
            ProjectId = component.ProjectId;
            ParentFolderId = component.ParentFolderId;
            IsEditable = component.IsEditable;
            IsSelected = component.IsSelected;
            IsExpanded = component.IsExpanded;
        }

        public ComponentDTO()
        {

        }

        public override string ToString()
        {
            return $"ComponentDTO:\n" +
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
