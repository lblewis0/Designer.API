using Designer.DAL.Interfaces;
using Designer.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer.DAL.Repositories
{
    public class ComponentRepository : IComponentRepository
    {
        private readonly SqlConnection _connection;
        public ComponentRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        protected Component Mapper(SqlDataReader reader)
        {
            return new Component
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                CreationDate = (DateTime)reader["CreationDate"],
                LastUpdateDate = (DateTime)reader["LastUpdateDate"],
                ProjectId = (int)reader["ProjectId"],
                ParentFolderId = (int)reader["ParentFolderId"],
                IsEditable = (bool)reader["IsEditable"],
                IsSelected = (bool)reader["IsSelected"],
                IsExpanded = (bool)reader["IsExpanded"]
            };
        }

        public void Create(Component component)
        {
            Console.WriteLine("ComponentRepository.Create(Component component).start");

            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "INSERT INTO Components (Name, CreationDate, LastUpdateDate, ProjectId, ParentFolderId, IsEditable, IsSelected, IsExpanded)" +
                    "VALUES (@name, @creationDate, @lastUpdateDate, @projectId, @parentFolderId, @isEditable, @isSelected, @isExpanded)";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("name", component.Name);
                cmd.Parameters.AddWithValue("creationDate", component.CreationDate);
                cmd.Parameters.AddWithValue("lastUpdateDate", component.LastUpdateDate);
                cmd.Parameters.AddWithValue("projectId", component.ProjectId);
                cmd.Parameters.AddWithValue("parentFolderId", component.ParentFolderId);
                cmd.Parameters.AddWithValue("isEditable", component.IsEditable);
                cmd.Parameters.AddWithValue("isSelected", component.IsSelected);
                cmd.Parameters.AddWithValue("isExpanded", component.IsExpanded);

                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
            }

            Console.WriteLine("ComponentRepository.Create(Component component).end");

        }

        public List<Component> GetByParentFolder(Folder folder)
        {
            Console.WriteLine("ComponentRepository.GetByParentFolder(Folder folder).start");

            List<Component> components = new List<Component>();
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "SELECT * FROM components where ParentFolderId = @id";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("id", folder.Id);

                _connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        components.Add(Mapper(reader));
                    }
                }
                _connection.Close();
            }
            Console.WriteLine("ComponentRepository.GetByParentFolder(Folder folder).end");
            return components;
        }
    }
}
