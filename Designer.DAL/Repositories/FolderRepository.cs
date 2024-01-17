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
                ParentFolderId = (int)reader["ParentFolderId"]
            };
        }

        public void Create(Folder folder)
        {
            Console.WriteLine("FolderRepository.Create(Folder folder).start");

            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "INSERT INTO Folders (Name, CreationDate, LastUpdateDate, ProjectId, ParentFolderId)" +
                    "VALUES (@name, @creationDate, @lastUpdateDate, @projectId, @parentFolderId)";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("name", folder.Name);
                cmd.Parameters.AddWithValue("creationDate", folder.CreationDate);
                cmd.Parameters.AddWithValue("lastUpdateDate", folder.LastUpdateDate);
                cmd.Parameters.AddWithValue("projectId", folder.ProjectId);
                cmd.Parameters.AddWithValue("parentFolderId", folder.ParentFolderId);

                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
            }

            Console.WriteLine("FolderRepository.Create(Folder folder).end");

        }


    }
}
