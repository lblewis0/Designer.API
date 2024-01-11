﻿using Designer.DAL.Interfaces;
using Designer.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designer.DAL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly SqlConnection _connection;

        public ProjectRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        protected Project Mapper(SqlDataReader reader)
        {
            return new Project
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                CreationDate = (DateTime)reader["CreationDate"],
                LastUpdateDate = (DateTime)reader["LastUpdateDate"],
                UserId = (int)reader["UserId"]
            };
        }

        public void Create(Project project)
        {
            Console.WriteLine("ProjectRepository.Create(Project project).start");

            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "INSERT INTO Projects (Name, CreationDate, LastUpdateDate, UserId)" +
                    "VALUES (@name, @creationDate, @lastUpdateDate, @userId)";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("name", project.Name);
                cmd.Parameters.AddWithValue("creationDate", project.CreationDate);
                cmd.Parameters.AddWithValue("lastUpdateDate", project.LastUpdateDate);
                cmd.Parameters.AddWithValue("userId", project.UserId);

                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
            }

            Console.WriteLine("ProjectRepository.Create(Project project).end");

        }

    }
}