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
    public class UserRepository : IUserRepository
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        protected User Mapper(SqlDataReader reader)
        {
            return new User
            {
                Id = (int)reader["Id"],
                Firstname = (string)reader["Firstname"],
                Lastname = (string)reader["Lastname"],
                Email = (string)reader["Email"],
                Username = (string)reader["Username"],
                Password = (string)reader["Password"],
                UserRole = (string)reader["UserRole"],
                ActiveProjectId = (int)reader["ActiveProjectId"]
            };
        }

        public void Create(User user)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "INSERT INTO Users (Firstname, Lastname, Email, Username, Password, UserRole, ActiveProjectId)" +
                    "VALUES (@firstname, @lastname, @email, @username, @password, @userRole, @activeProjectId)";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("firstname", user.Firstname);
                cmd.Parameters.AddWithValue("lastname", user.Lastname);
                cmd.Parameters.AddWithValue("email", user.Email);
                cmd.Parameters.AddWithValue("username", user.Username);
                cmd.Parameters.AddWithValue("password", user.Password);
                cmd.Parameters.AddWithValue("userRole", user.UserRole);
                cmd.Parameters.AddWithValue("activeProjectId", user.ActiveProjectId);

                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();

            }
        }

        public void Delete(int id)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "DELETE FROM Users WHERE Id = @id";
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("id", id);

                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public User GetById(int id)
        {
            User user = null;
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "SELECT * FROM Users WHERE Id = @id";
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("id", id);

                _connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) user = Mapper(reader);
                }
                _connection.Close();
            }
            return user;
        }

        public User GetByUsername(string username)
        {
            Console.WriteLine("UserRepository.GetByUsername(string username).start");
            User user = null;
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "SELECT * FROM Users WHERE Username = @username";
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("username", username);

                _connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) user = Mapper(reader);
                }
                _connection.Close();
            }
            Console.WriteLine("UserRepository.GetByUsername(string username).end");
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "SELECT * FROM Users";
                cmd.CommandText = sql;

                _connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(Mapper(reader));
                    }
                }
                _connection.Close();
            }
            return users;
        }

        public void UpdateActiveProject(User user)
        {
            Console.WriteLine("UserRepository.UpdateActiveProject(int userId, int activeId).start");

            using (SqlCommand cmd = _connection.CreateCommand())
            {
                string sql = "UPDATE Users SET ActiveProjectId=@newid WHERE Id=@userid";
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("newid", user.ActiveProjectId);
                cmd.Parameters.AddWithValue("userid", user.Id);

                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
            }

            Console.WriteLine("UserRepository.UpdateActiveProject(int userId, int activeId).end");
        }
    }
}
