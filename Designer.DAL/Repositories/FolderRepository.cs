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
    public class FolderRepository : IFolderRepository
    {
        private readonly SqlConnection _connection;
        public FolderRepository(SqlConnection connection) 
        {
            _connection = connection;
        }

        protected Folder Mapper(SqlDataReader reader)
        {
            return new Folder
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

        public void Create(Folder folder)
        {
            Console.WriteLine("FolderRepository.Create(Folder folder).start");

            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "INSERT INTO Folders (Name, CreationDate, LastUpdateDate, ProjectId, ParentFolderId, IsEditable, IsSelected, IsExpanded)" +
                    "VALUES (@name, @creationDate, @lastUpdateDate, @projectId, @parentFolderId, @isEditable, @isSelected, @isExpanded)";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("name", folder.Name);
                cmd.Parameters.AddWithValue("creationDate", folder.CreationDate);
                cmd.Parameters.AddWithValue("lastUpdateDate", folder.LastUpdateDate);
                cmd.Parameters.AddWithValue("projectId", folder.ProjectId);
                cmd.Parameters.AddWithValue("parentFolderId", folder.ParentFolderId);
                cmd.Parameters.AddWithValue("isEditable", folder.IsEditable);
                cmd.Parameters.AddWithValue("isSelected", folder.IsSelected);
                cmd.Parameters.AddWithValue("isExpanded", folder.IsExpanded);

                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
            }

            Console.WriteLine("FolderRepository.Create(Folder folder).end");

        }

        public void DeleteByProjectId(int projectId)
        {
            Console.WriteLine("FolderRepository.DeleteByProjectId(int projectId).start");

            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "DELETE FROM Folders WHERE ProjectId=@projectId";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("projectId", projectId);

                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
            }

            Console.WriteLine("FolderRepository.DeleteByProjectId(int projectId).end");
        }

        public void Rename(Folder folder)
        {
            Console.WriteLine("FolderRepository.Rename(Folder folder).start");

            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "UPDATE Projects SET Name=@name WHERE Id=@id";
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("name", folder.Name);
                cmd.Parameters.AddWithValue("id", folder.Id);

                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
            }

            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "UPDATE Projects SET LastUpdateDate=@lastUpdateDate WHERE Id=@id";
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("lastUpdateDate", folder.LastUpdateDate);
                cmd.Parameters.AddWithValue("id", folder.Id);

                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
            }

            Console.WriteLine("FolderRepository.Rename(Folder folder).end");
        }

        public void UpdateLastUpdateDate(Folder folder)
        {
            Console.WriteLine("FolderRepository.UpdateLastUpdateDate(Folder folder).start");

            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "UPDATE Folders SET LastUpdateDate=@lastUpdateDate WHERE Id=@id";
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("lastUpdateDate", folder.LastUpdateDate);
                cmd.Parameters.AddWithValue("id", folder.Id);

                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
            }

            Console.WriteLine("FolderRepository.UpdateLastUpdateDate(Folder folder).end");
        }

        public void UpdateIsSelected(Folder folder)
        {
            Console.WriteLine("FolderRepository.UpdateIsSelected(Folder folder).start");

            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "UPDATE Folders SET IsSelected=@isSelected WHERE Id=@id";
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("isSelected", folder.IsSelected);
                cmd.Parameters.AddWithValue("id", folder.Id);

                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
            }

            Console.WriteLine("FolderRepository.UpdateIsSelected(Folder folder).end");
        }

        public void UpdateIsExpanded(Folder folder)
        {
            Console.WriteLine("FolderRepository.UpdateIsExpanded(Folder folder).start");

            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "UPDATE Folders SET IsExpanded=@isExpanded WHERE Id=@id";
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("isExpanded", folder.IsExpanded);
                cmd.Parameters.AddWithValue("id", folder.Id);

                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
            }

            Console.WriteLine("FolderRepository.UpdateIsExpanded(Folder folder).end");
        }



        public Folder GetByProjectId(Project project)
        {
            Console.WriteLine("FolderRepository.GetByProjectId(Project project).start");
            Folder folder = null;

            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "SELECT * FROM Folders where ProjectId = @projectId and ParentFolderId = 0";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("projectId", project.Id);

                _connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        folder = Mapper(reader);
                    }
                }
                _connection.Close();
            }
            Console.WriteLine("FolderRepository.GetByProjectId(Project project).end");
            return folder;
        }

        public List<Folder> GetByParentFolder(Folder folder)
        {
            Console.WriteLine("FolderRepository.GetByParentFolder(Folder folder).start");

            List<Folder> folders = new List<Folder>();
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "SELECT * FROM folders where ParentFolderId = @id";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("id", folder.Id);

                _connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        folders.Add(Mapper(reader));
                    }
                }
                _connection.Close();
            }
            Console.WriteLine("FolderRepository.GetByParentFolder(Folder folder).end");
            return folders;
        }

        public List<Folder> GetByParentFolderIdAndNameLike(int parentFolderId, string name)
        {
            Console.WriteLine("FolderRepository.GetByParentFolderIdAndNameLike(int parentFolder, string name).start");

            List<Folder> folders = new List<Folder>();
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "SELECT * FROM folders WHERE ParentFolderId = @id AND (Name LIKE @name OR Name = @name2)";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("id", parentFolderId);
                cmd.Parameters.AddWithValue("name", name + " (%");
                cmd.Parameters.AddWithValue("name2", name);

                _connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        folders.Add(Mapper(reader));
                    }
                }
                _connection.Close();
            }
            Console.WriteLine("FolderRepository.GetByParentFolderIdAndNameLike(int parentFolder, string name).end");
            return folders;
        }

        public Folder GetByParentFolderIdAndName(int parentFolderId, string name)
        {
            Console.WriteLine("FolderRepository.GetByParentFolderIdAndName(int parentFolderId, string name).start");
            Folder folder = null;

            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "SELECT * FROM Folders where ParentFolderId = @id and Name = @name";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("id", parentFolderId);
                cmd.Parameters.AddWithValue("name", name);

                _connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        folder = Mapper(reader);
                    }
                }
                _connection.Close();
            }
            Console.WriteLine("FolderRepository.GetByParentFolderIdAndName(int parentFolderId, string name).end");
            return folder;
        }
    }
}
